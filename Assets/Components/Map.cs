using System.Collections.Generic;
using UnityEngine;

namespace Client
{
    public struct Map
    {
        public List<MapCell> MapCells;

        public Dictionary<MapCell,Object> GeneratedMapCells;
    }
}