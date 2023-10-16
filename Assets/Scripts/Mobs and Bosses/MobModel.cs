using UnityEngine;

[CreateAssetMenu(fileName = "Mob", menuName = "Models/Mob")]
public class MobModel : ScriptableObject
{
    [SerializeField] private Sprite mobSprite;
    [SerializeField] private float health;
    public float GetHealth()
    {
        return health;
    }

    public Sprite GetSprite()
    {
        return mobSprite;
    }
}
