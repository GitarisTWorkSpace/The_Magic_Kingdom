using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Models/Character")]
public class CharacterModel : ScriptableObject
{
    [SerializeField] private Sprite characterSprite;
    [SerializeField] private int characterIndex;
    [SerializeField] private string type;
    [SerializeField] private string powerType;

    [SerializeField] private float damage;
    [SerializeField] private float damageRate;

    public int GetCharacterIndex() => characterIndex;
    public Sprite GetCharacterSprite() => characterSprite;
    public string GetCharacterType() => type;
    public string GetChracterPowerType() => powerType;
    public float GetDamage() => damage;
    public float GetDamageRate() => damageRate;
}
