using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils;
using Leopotam.Ecs;

namespace Client
{
    public class GenerateMapSystem : IEcsRunSystem
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

                if (map.GeneratedMapCells.Count <= 0 || !(player.PlayerTransform.transform.position.z >
                                                          map.GeneratedMapCells.Last(x => x.Key.ID == 5).Key.SpawnPos
                                                              .z)) continue;

                var startSpawnPos = map.GeneratedMapCells.Last().Key.SpawnPos;
                var offset = new Vector3(0, 0, 10);
                var cells = new List<MapCell>();
                var startId = 0;
                for (var _ = 0; _ < 6; _++)
                {
                    for (var __ = 0; __ < 6; __++)
                    {
                        var cell = new MapCell
                        {
                            SpawnPos = startSpawnPos,
                            Lenght = offset,
                            PlatformGameObject = _sceneData.tilePrefab,
                            ID = startId
                        };
                        cells.Add(cell);
                        startSpawnPos += offset;
                        startId++;
                    }
                    startSpawnPos.x = _*10;
                    startSpawnPos.z = 0;
                }
                map.MapCells.AddRange(cells);
            }
        }
    }
}