using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class ResourceBank : MonoBehaviour
    {
        private readonly Dictionary<GameResource, ObservableInt> _resources = new();
        
        public ResourceBank()
        {
            _resources.Add(GameResource.FoodProductionLevel, new ObservableInt(1));
            _resources.Add(GameResource.GoldProductionLevel, new ObservableInt(1));
            _resources.Add(GameResource.HumanProductionLevel, new ObservableInt(1));
            _resources.Add(GameResource.StoneProductionLevel, new ObservableInt(1));
            _resources.Add(GameResource.WoodProductionLevel, new ObservableInt(1));
            _resources.Add(GameResource.Food, new ObservableInt(0));
            _resources.Add(GameResource.Gold, new ObservableInt(0));
            _resources.Add(GameResource.Humans, new ObservableInt(0));
            _resources.Add(GameResource.Stone, new ObservableInt(0));
            _resources.Add(GameResource.Wood, new ObservableInt(0));
        }

        public void ChangeResource(GameResource r, int v)
        {
            _resources[r].Value += v;
        }
        
        public static GameResource MatchResourceWithLevel(GameResource resource)
        {
            return resource switch
            {
                GameResource.Food => GameResource.FoodProductionLevel,
                GameResource.Gold => GameResource.GoldProductionLevel,
                GameResource.Humans => GameResource.HumanProductionLevel,
                GameResource.Wood => GameResource.WoodProductionLevel,
                GameResource.Stone => GameResource.StoneProductionLevel,
                _ => GameResource.FoodProductionLevel
            };
        }
        
        public ObservableInt GetResource(GameResource r)
        {
            return _resources[r];
        }
    }
}