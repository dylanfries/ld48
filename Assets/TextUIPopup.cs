using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUIPopup : MonoBehaviour
{
    public GameObject UIPanel;
    public Text textBox;

    public int timesOpened = 0;

    public bool closeWithTimer = false;
    public float closeTimer = 3f;


    public string[] textToPrint;
    private void OnTriggerEnter2D(Collider2D collision) {

        UIPanel.SetActive(true);

        if (timesOpened < textToPrint.Length)
            textBox.text = textToPrint[timesOpened];
        else{
            textBox.text = textToPrint[textToPrint.Length - 1];
        }

        timesOpened++;

        if(closeWithTimer){
            StartCoroutine(CloseWithTimer(closeTimer));

        }
    }

    private IEnumerator CloseWithTimer(float t){
        yield return new WaitForSeconds(t);
        Close();
    }

    private void OnTriggerExit2D(Collider2D collision) {
        Close();
    }

    private void Close(){
        UIPanel.SetActive(false);
        StopAllCoroutines();
    }
}
