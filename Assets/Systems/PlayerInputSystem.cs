using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerInputData> _filter; // фильтр, который выдаст нам все сущности, у которых есть компонент PlayerInputData
  
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var input = ref _filter.Get1(i);
                input.MoveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")); // заполняем данные
            }
        }
    }
}