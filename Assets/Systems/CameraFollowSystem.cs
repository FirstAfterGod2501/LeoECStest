using Leopotam.Ecs;
using UnityEngine;
using Utils;

namespace Client
{
    public class CameraFollowSystem : IEcsRunSystem
    {
        private EcsFilter<Player> _filter;
        
        private SceneData _sceneData;
        
        private Vector3 _currentVelocity; 
 
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var player = ref _filter.Get1(i);
                var currentPos = _sceneData.mainCamera.transform.position;
                currentPos = Vector3.SmoothDamp(currentPos,_sceneData.followOffset, ref _currentVelocity, _sceneData.smoothTime);
                _sceneData.mainCamera.transform.position = currentPos;
            }
        }
    }
}