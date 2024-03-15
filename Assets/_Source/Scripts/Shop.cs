using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts
{
    public class ProductionBuyer : MonoBehaviour
    {
        [SerializeField] private GameResource res;
        [SerializeField] private ResourceBank bank;
        [SerializeField] private TMP_Text text;
        [SerializeField] private Button buttonOfProduction;

        private float x = 0;

        private void Start()
        {
            text.text = $"Increase {res.ToString()} on {Price} coins";
        }

        private int Price => 10 * bank.GetResource(ResourceBank.MatchResourceWithLevel(res)).Value;

        public void BuyInShop()
        {
            var value = bank.GetResource(res).Value;
            if (value < Price) return;
            
            bank.GetResource(res).Value -= Price;
            bank.GetResource(ResourceBank.MatchResourceWithLevel(res)).Value += 1;
            Fill();
            text.text = $"Increase {res.ToString()} on {Price} coins";
        }

        private void Fill()
        {
            buttonOfProduction.interactable = false;
            StartCoroutine(FillProductionBuyer(100, 0.01f));
            buttonOfProduction.interactable = true;
        }

        private IEnumerator FillProductionBuyer(int steps, float dist)
        {
            for (int i = 0; i < steps; ++i)
            {
                buttonOfProduction.image.fillAmount = 0;
                x += dist;
                yield return new WaitForEndOfFrame();
            }

            x = 0;
            buttonOfProduction.image.fillAmount = 0;
        }
    }
}
