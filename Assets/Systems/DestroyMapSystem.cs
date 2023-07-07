using System.Linq;
using Leopotam.Ecs;
using UnityEngine;
using Utils;

namespace Client
{
    public class DestroyMapSystem : IEcsRunSystem
    {
        private EcsWorld _ecsWorld;
        
        private EcsFilter<Map> _filter;

        private EcsFilter<Player> _playerFilter;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var map = ref _filter.Get1(i);
                ref var player = ref _playerFilter.Get1(1);
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