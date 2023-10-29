using UnityEngine;

[CreateAssetMenu(fileName = "Advice", menuName = "Models/Advice")]
public class AdviceModel : ScriptableObject
{
    [SerializeField] private string adviceText;

    public string GetAdvice() => adviceText;
}
