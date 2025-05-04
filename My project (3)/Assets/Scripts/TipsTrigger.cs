using TMPro;
using UnityEngine;

public class TipsTrigger : MonoBehaviour
{
    [Header("Text Hinds")]
    [TextArea(3, 10)]
    [SerializeField] private string message;
    [SerializeField] private TypewriterTMP typewriterTMP;
    [SerializeField] private TipsManager tipsManager;

    private void Start()
    {
        tipsManager = GetComponentInChildren<TipsManager>();   
        typewriterTMP = GetComponentInChildren<TypewriterTMP>();   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
if (collision.CompareTag("Player"))
        {
            tipsManager.displayTipEvent?.Invoke(message);
            typewriterTMP.TextWrite();
        }

    }
private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            tipsManager.disableTipEvent?.Invoke();
        }
    }
}
