using System.Collections;
using System.Collections.Generic;
using SO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LauncherScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI statusTMP;
    [SerializeField] private Slider slider;

    [SerializeField] private bool triggerError;
    
    [Header("Channels")] 
    [SerializeField] private ModalWindowChannelSO modalWindowChannelSo;
    
    void Start()
    {
        slider.value = 0;
        statusTMP.text = "Loading data...";

        StartCoroutine("FirstPhase");
    }

    IEnumerator FirstPhase()
    {
        yield return new WaitForSeconds(1);
        slider.value = .5f;
        statusTMP.text = "Connecting to the server...";
        StartCoroutine("SecondPhase");
    }
    
    IEnumerator SecondPhase()
    {
        yield return new WaitForSeconds(1);

        if (triggerError)
        {
            modalWindowChannelSo.RaiseOnRequestModal("error_server", ReloadSecondPhase);
        }
        else
        {
            slider.value = 1f;
            statusTMP.text = "Starting!";
            SceneManager.LoadScene("Menu");
        }
    }

    private void ReloadSecondPhase(ModalWindowResponseEnum response)
    {
        if (response == ModalWindowResponseEnum.Confirm)
        {
            StartCoroutine("SecondPhase");
            return;
        }
        
        // If not confirmed is Declined
        Application.Quit();
    }
}
