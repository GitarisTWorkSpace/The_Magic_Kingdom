using UnityEngine;

[CreateAssetMenu(fileName = "Abilities", menuName = "Models/Abilities")]
public class AbilitiesModel : ScriptableObject
{
    [SerializeField] [TextArea(5,5)] private string abilitiDescription;

    public string GetAbilitiDescription() => abilitiDescription;

    public virtual void Abiliti()
    {
        Debug.Log("Abilities");
    }
}
