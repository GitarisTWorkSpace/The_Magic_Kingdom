using TMPro;
using UnityEngine;

public class CristalView : MonoBehaviour
{
    [SerializeField] private CristalModel cristalModel;

    [SerializeField] private TMP_Text cristalText;
    void Update()
    {
        cristalText.text = cristalModel.GetCristalCount().ToString();
    }
}
