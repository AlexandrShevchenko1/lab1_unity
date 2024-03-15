using UnityEngine;

namespace Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private ResourceBank bank;

        private void Start()
        {
            bank.ChangeResource(GameResource.Humans, 10);
            bank.ChangeResource(GameResource.Food, 5);
            bank.ChangeResource(GameResource.Wood, 5);
        }
    }
}