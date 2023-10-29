using UnityEngine;

public class AdviceController : MonoBehaviour
{
    [SerializeField] private AdviceModel[] advices;

    public string GetRandomAdvice()
    {
        int rndAdvice = Random.Range(0, advices.Length);
        return advices[rndAdvice].GetAdvice();
    }
}
