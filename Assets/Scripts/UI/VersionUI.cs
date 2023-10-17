using TMPro;
using UnityEngine;

namespace UI
{
    public class VersionUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI versionText;

        private void Start()
        {
            versionText.text = $"ver: {Application.version}";
        }
    }
}
