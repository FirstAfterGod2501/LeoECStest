using Leopotam.Ecs;
using UnityEngine;
using Utils;

namespace Client {
    public class EcsStartup : MonoBehaviour
    {
        public SceneData sceneData;

        private EcsWorld _ecsWorld;
        
        private EcsSystems _updateSystems;
        
        private EcsSystems _fixedUpdateSystems; // новая группа систем

        private void Start()
        {
            _ecsWorld = new EcsWorld();
            _updateSystems = new EcsSystems(_ecsWorld);
            _fixedUpdateSystems = new EcsSystems(_ecsWorld);

            _updateSystems
                .Add(new PlayerInitSystem())
                .Add(new PlayerInputSystem())
                .Inject(sceneData);

            _fixedUpdateSystems.Add(new PlayerMoveSystem()); // добавляем систему движения
            _fixedUpdateSystems.Add(new CameraFollowSystem()).Inject(sceneData);
      
            // Инициализируем группы систем
            _updateSystems.Init();
            _fixedUpdateSystems.Init();
        }

        private void Update()
        {
            _updateSystems?.Run();
        }

        private void FixedUpdate()
        {
            _fixedUpdateSystems?.Run(); // запускаем их каждый тик FixedUpdate()
        }

        private void OnDestroy()
        {
            _updateSystems?.Destroy();
            _updateSystems = null;
            _fixedUpdateSystems?.Destroy();
            _fixedUpdateSystems = null;
            _ecsWorld?.Destroy();
            _ecsWorld = null;
        }
    }
}