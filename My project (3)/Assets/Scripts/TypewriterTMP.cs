using UnityEngine;
using TMPro;
using System.Collections;
using Unity.VisualScripting;

public class TypewriterTMP : MonoBehaviour
{
    public float delay = 0.05f;
    public int active;
    public string fullText;
    public string currentText = "";

    public TMP_Text tmpText;
    private void Start()
    {
        tmpText = GetComponent<TextMeshPro>();
    }
    public void TextWrite()
    {
        if (active < 1)
        {
            active++;
            Debug.Log(active);
            tmpText = GetComponent<TMP_Text>();
            fullText = tmpText.text;
            tmpText.text = "";
            StartCoroutine(ShowText());
        }

    }
    public  IEnumerator ShowText()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            tmpText.text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }
}