using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class TipsManager : MonoBehaviour
{
    public Action<string> displayTipEvent;
    public Action disableTipEvent;
    [SerializeField] private TMP_Text messageText;
    private Animator anim;
    private int activeTips;
    [SerializeField] private Transform healthBarTransform;
    private Camera _camera;
    private void Awake()
    {
        _camera = Camera.main;   
    }
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        healthBarTransform.rotation = _camera.transform.rotation;

    }
    private void displayTip(string message)
    {
        messageText.text = message;
        anim.SetInteger("state", ++activeTips);
    }
    private void OnEnable()
    {
        displayTipEvent += displayTip;
        disableTipEvent += disableTip;
    }
    private void OnDisable()
    {
        displayTipEvent -= displayTip;
        disableTipEvent -= disableTip;
    }
    private void disableTip()
    {
        anim.SetInteger("state", --activeTips);
    }

}
