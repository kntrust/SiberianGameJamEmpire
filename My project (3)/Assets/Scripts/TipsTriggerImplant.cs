using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Live2D;
using Live2D.Cubism.Core;

public class TipsTriggerImplant : MonoBehaviour
{
    [Header("Text Hinds")]
    [TextArea(3, 10)]
    [SerializeField] private string message;
    [SerializeField] private TipsManager tipsManager;
    [SerializeField] private TipsTriggerLong triggerLong;
    [SerializeField] private bool boolDestroy;
    [SerializeField] private CubismModel model;
    [SerializeField] private CubismParameter param;
    private void Start()
    {
        //model = this.FindCubismModel();
        //param = model.Parameters[1];
        tipsManager = GetComponentInChildren<TipsManager>(); 
        
    }
    private void LateUpdate()
    {
        if (triggerLong.earImplant)
        {
            model.Parameters[37 - 1].Value = 1;
        }
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && boolDestroy)
        {
            Destroy(gameObject);
            triggerLong.earImplant = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            boolDestroy = true;
            tipsManager.displayTipEvent?.Invoke(message);
        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            boolDestroy = false;
            tipsManager.disableTipEvent?.Invoke();
        }
    }
}
