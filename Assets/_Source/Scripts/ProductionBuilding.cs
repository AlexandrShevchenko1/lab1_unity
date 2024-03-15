using System;
using System.Collections;
using UnityEngine;

namespace Scripts
{
    public class ProductionBuilding : MonoBehaviour
    {
        [SerializeField] private GameResource currentRes;
        [SerializeField] private ResourceBank bank;

        private int Delta => bank.GetResource(ResourceBank.MatchResourceWithLevel(currentRes)).Value;

        public float ProductionTime => (1.0f * (1.01f - bank.GetResource(ResourceBank.MatchResourceWithLevel(currentRes)).Value / 100.0f));
        
        public void Increase()
        {
            StartCoroutine(FillBuyer());
            bank.ChangeResource(currentRes, Delta);
        }

        private IEnumerator FillBuyer()
        {
            yield return new WaitForSeconds(ProductionTime);
        }
    }
}
