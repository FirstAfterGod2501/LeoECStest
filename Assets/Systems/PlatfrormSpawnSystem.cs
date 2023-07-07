using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils;
using Leopotam.Ecs;

namespace Client
{
    public class PlatformSpawnSystem : IEcsRunSystem
    {
        private EcsWorld _ecsWorld;
        
        private EcsFilter<Map> _filter;

        private EcsFilter<Player> _playerFilter;

        private SceneData _sceneData;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var map = ref _filter.Get1(i);
                ref var player = ref _playerFilter.Get1(1);
                var mapForLambda = map;
                foreach (var mapCell in map.MapCells.Where(mapCell =>
                             !mapForLambda.GeneratedMapCells.ContainsKey(mapCell)))
                    {
                        map.GeneratedMapCells.Add(mapCell,Object.Instantiate(mapCell.PlatformGameObject, mapCell.SpawnPos, Quaternion.identity));
                    }

                var playerForLinq = player;
                foreach (var generatedMapCell in map.GeneratedMapCells.Where(generatedMapCell =>
                             playerForLinq.PlayerTransform.transform.position.z > generatedMapCell.Key.SpawnPos.z+20))
                {
                    Object.Destroy(generatedMapCell.Value);
                    //map.GeneratedMapCells.Remove(generatedMapCell.Key);
                }
            }
        }
    }
}