using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;
using Utils;

namespace Client {
    public class PlatfromInitSystem : IEcsInitSystem
    {
        private EcsWorld _ecsWorld;
        
        private SceneData _sceneData;

        public void Init()
        {
            var startSpawnPos = new Vector3(0,0,0);
            var offset = new Vector3(0, 0, 10);
            var cells = new List<MapCell>();
            int startId = 0;
            var MapEntity = _ecsWorld.NewEntity();
            for (var _ = 0; _ < 6; _++)
            {
                for (var i = 0; i < 6; i++)
                {
                    ref var cell = ref MapEntity.Get<MapCell>();
                    cell.SpawnPos = startSpawnPos;
                    cell.Lenght = offset;
                    cell.PlatformGameObject = _sceneData.tilePrefab;
                    cell.ID = startId;
                    cells.Add(cell);
                    startSpawnPos += offset;
                    startId++;
                }
                startSpawnPos.x = _*10;
                startSpawnPos.z = 0;
            }

            ref var mapCells = ref MapEntity.Get<Map>();
            mapCells.MapCells = cells;
            mapCells.GeneratedMapCells = new Dictionary<MapCell, Object>();
        }
    }
}