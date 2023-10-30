using UnityEngine;

[CreateAssetMenu(fileName = "Advice", menuName = "Models/Advice")]
public class AdviceModel : ScriptableObject
{
    [SerializeField] [TextArea(4, 6)] private string adviceText;

    public string GetAdvice() => adviceText;
}
