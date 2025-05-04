using TMPro;
using UnityEngine;

public class TipsTriggerLong : MonoBehaviour
{
    [Header("Text Hinds")]
    [TextArea(3, 10)]
    [SerializeField] private string message;
    [SerializeField] private TypewriterTMP typewriterTMP;
    [SerializeField] private TipsManager tipsManager;
    public bool earImplant;

    private void Start()
    {
        tipsManager = GetComponentInChildren<TipsManager>();   
        typewriterTMP = GetComponentInChildren<TypewriterTMP>();   
    }
    private void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
if (collision.CompareTag("Player") )
        {
            if (earImplant)
            {
                tipsManager.displayTipEvent?.Invoke(message);
                typewriterTMP.TextWrite();
                Debug.Log("sigma");
            }
            }
        else
        {
            return;
        }

    }
private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && earImplant)
        {
            tipsManager.disableTipEvent?.Invoke();
        }
    }
}
