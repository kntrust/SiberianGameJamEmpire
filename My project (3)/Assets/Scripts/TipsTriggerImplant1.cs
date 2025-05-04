using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.InputSystem;

public class TipsTriggerHouse : MonoBehaviour
{
    [Header("Text Hinds")]
    [TextArea(3, 10)]
    [SerializeField] private string message;
    [SerializeField] private TipsManager tipsManager;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private HouseWind houseWind;
    [SerializeField] private bool boolDestroy;
    [SerializeField] private Animator anim;

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
        houseWind.enabled = !houseWind.enabled;
            Destroy(gameObject);
    }
    private void Update()
    {
            if(boolDestroy && Input.GetKeyDown(KeyCode.E))
            {
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
