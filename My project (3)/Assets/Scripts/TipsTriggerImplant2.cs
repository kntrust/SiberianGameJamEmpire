using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.InputSystem;

public class TipsTriggerBlackout : MonoBehaviour
{
    [Header("Text Hinds")]
    [TextArea(3, 10)]
    [SerializeField] private string message;
    [SerializeField] private TipsManager tipsManager;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private bool boolDestroy;
    [SerializeField] private Animator anim;
    [SerializeField] private BlackoutManager blackoutManager;
    public int counter;

    private void Start()
    {
        tipsManager = GetComponentInChildren<TipsManager>();
        anim = GameObject.Find("вовк").GetComponent<Animator>();
        playerMovement = GameObject.Find("вовк").GetComponent<PlayerMovement>();
    }
    IEnumerator TimerBlow()
    {
            yield return new WaitForSeconds(2f);
            playerMovement.enabled = !playerMovement.enabled;
        gameObject.SetActive(false);
        blackoutManager.Func();

    }
    private void Update()
    {
            if(boolDestroy && Input.GetKeyDown(KeyCode.E) && counter <= 3)
            {
             counter++;
             anim.Play("Blow");
             if (!playerMovement.FacingRight)
             {
                playerMovement.Flip();
                playerMovement.enabled = !playerMovement.enabled;
                 
             }
             else 
             {
                playerMovement.enabled = !playerMovement.enabled;
             }
             StartCoroutine(TimerBlow());
            }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            tipsManager.displayTipEvent?.Invoke(message);
            boolDestroy = true;
        }
        

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            tipsManager.disableTipEvent?.Invoke();
            boolDestroy = false;
        }
    }
}
