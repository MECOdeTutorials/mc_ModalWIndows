using System.Collections;
using System.Collections.Generic;
using SO;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    [Header("Channels")] 
    [SerializeField] private ModalWindowChannelSO modalWindowChannelSo;
    
    void Start()
    {
        StartCoroutine("Countdown");
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(3);
        
        modalWindowChannelSo.RaiseOnRequestModal("confirm_exit", ModalWindowUserResponse);
    }

    private void ModalWindowUserResponse(ModalWindowResponseEnum response)
    {
        switch (response)
        {
            case ModalWindowResponseEnum.Confirm:
                Debug.Log("YOU CONFIRMED!");
                break;
            case ModalWindowResponseEnum.Action:
                Debug.Log("YOU pressed action!??");
                break;
            case ModalWindowResponseEnum.Decline:
                Debug.Log("You declined...");
                break;
        }
    }
}
