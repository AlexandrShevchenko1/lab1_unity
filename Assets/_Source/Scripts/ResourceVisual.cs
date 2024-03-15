using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Scripts
{
    public class ResourceVisual : MonoBehaviour
    {
        [SerializeField] private ResourceBank bank;
        [SerializeField] private List<TMP_Text> texts;
        
        private void Awake()
        {
            var list = new List<GameResource> { GameResource.Food, GameResource.Gold, GameResource.Humans, GameResource.Stone, GameResource.Wood };
            foreach (var res in list)
            {
                bank.GetResource(res).OnValueChanged += value =>
                    texts[(int)res].text = $"{value}";
            }
        }
    }
}