using TMPro;
using UnityEngine;

namespace Spinner.Scripts
{
    public enum RewardType
    {
        Diamond,
        Gold,
        Heart,
    }
    public class PieceController : MonoBehaviour
    {
        [SerializeField] private RewardType Type;
        [SerializeField] private TextMeshProUGUI TypeText;
        

        private void Awake()
        {
            TypeText.text = Type.ToString();
        }
    }
}