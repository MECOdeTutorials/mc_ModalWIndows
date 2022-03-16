using System;
using System.Collections;
using System.Collections.Generic;
using SO;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ModalWindow : MonoBehaviour
{
    // Scene references
    [SerializeField] private TextMeshProUGUI titleTMP;
    [SerializeField] private TextMeshProUGUI contentTMP;
    [SerializeField] private Button confirmButton;
    [SerializeField] private Button actionButton;
    [SerializeField] private Button declineButton;

    private TextMeshProUGUI confirmBtnTMP;
    private TextMeshProUGUI actionBtnTMP;
    private TextMeshProUGUI declineBtnTMP;

    private UnityAction<ModalWindowResponseEnum> responseAction;

    private void Awake()
    {
        confirmBtnTMP = confirmButton.GetComponentInChildren<TextMeshProUGUI>();
        actionBtnTMP = actionButton.GetComponentInChildren<TextMeshProUGUI>();
        declineBtnTMP = declineButton.GetComponentInChildren<TextMeshProUGUI>();
    }

    /// <summary>
    /// Handle window opening
    /// </summary>
    public void Show(ModalWindowDataSO data, UnityAction<ModalWindowResponseEnum> action)
    {
        titleTMP.text = data.title;
        contentTMP.text = data.content;

        confirmBtnTMP.text = data.confirmBtnText;
        confirmButton.gameObject.SetActive(data.hasConfirmButton);
        
        actionBtnTMP.text = data.actionBtnText;
        actionButton.gameObject.SetActive(data.hasActionButton);
        
        declineBtnTMP.text = data.declineBtnText;
        declineButton.gameObject.SetActive(data.hasDeclineButton);

        responseAction = action;
        
        gameObject.SetActive(true);
    }

    /// <summary>
    /// Handle window closing
    /// </summary>
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    
    public void OnConfirmClicked()
    {
        responseAction?.Invoke(ModalWindowResponseEnum.Confirm);
        Hide();
    }

    public void OnActionClicked()
    {
        responseAction?.Invoke(ModalWindowResponseEnum.Action);
        Hide();
    }

    public void OnDeclineClicked()
    {
        responseAction?.Invoke(ModalWindowResponseEnum.Decline);
        Hide();
    }
}
