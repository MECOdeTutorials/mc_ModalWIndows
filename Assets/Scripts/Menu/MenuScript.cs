using SO;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    [Header("Channels")] 
    [SerializeField] private ModalWindowChannelSO modalWindowChannelSo;

    public void Exit()
    {
        modalWindowChannelSo.RaiseOnRequestModal("confirm_exit", ExitResponse);
    }

    private void ExitResponse(ModalWindowResponseEnum response)
    {
        if (response == ModalWindowResponseEnum.Decline)
        {
            Application.Quit();
        }
    }
}
