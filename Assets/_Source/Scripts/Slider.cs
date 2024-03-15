using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts
{
    public class Slider : MonoBehaviour
    {
        private float _x;
        [SerializeField] private Image image;
        [SerializeField] private ProductionBuilding builder;
        [SerializeField] private Button sliderButton;
        
        public void Fill()
        {
            sliderButton.interactable = false;
            StartCoroutine(FillSlider(Convert.ToInt32(builder.ProductionTime * 100), 1.0f / Convert.ToInt32(builder.ProductionTime * 100)));
            sliderButton.interactable = true;
        }

        private IEnumerator FillSlider(int numOfSteps, float distance)
        {
            for (int i = 0; i < numOfSteps; ++i)
            {
                image.fillAmount = _x;
                _x += distance;
                yield return new WaitForEndOfFrame();
            }
            _x = 0;
            image.fillAmount = 0;
        }
    }
}
