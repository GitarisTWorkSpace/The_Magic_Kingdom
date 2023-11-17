using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade", menuName = "Models/Upgrade")]
public class UpgradeAmountMoneyModel : ScriptableObject
{
    [SerializeField] private int[] needCoinToUpgrade;

    public int GetAmounMoneyToUpgradeCharacter(int index) => needCoinToUpgrade[index - 1];
}
