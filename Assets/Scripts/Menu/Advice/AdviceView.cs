using TMPro;
using UnityEngine;

public class AdviceView : MonoBehaviour
{
    [SerializeField] private AdviceController controller;
    [SerializeField] private TMP_Text adviceText;

    public void SetAdviceText() => adviceText.text = controller.GetRandomAdvice();
}
