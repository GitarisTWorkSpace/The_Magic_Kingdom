using TMPro;
using UnityEngine;

public class VersionView : MonoBehaviour
{
    [SerializeField] private TMP_Text versionText;
    private void Start()
    {
        versionText.text = Application.version.ToString();
    }
}
