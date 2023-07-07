using Leopotam.Ecs;
using UnityEngine;
using Utils;

namespace Client {
    public class PlayerInitSystem : IEcsInitSystem
    {
        private EcsWorld _ecsWorld;
        
        private SceneData _sceneData;

        public void Init()
        {
            var playerEntity = _ecsWorld.NewEntity();

            ref var player = ref playerEntity.Get<Player>();
            ref var inputData = ref playerEntity.Get<PlayerInputData>();
        
            // Спавним GameObject игрока
            var playerGo = Object.Instantiate(_sceneData.playerPrefab, _sceneData.playerSpawnPoint.position, Quaternion.identity);
            player.PlayerRigidbody = playerGo.GetComponent<Rigidbody>();
            player.PlayerSpeed = _sceneData.playerSpeed;
            player.PlayerTransform = _sceneData.PlayerTransform;
            player.PlayerTransform = playerGo.transform;
        }
    }
}
