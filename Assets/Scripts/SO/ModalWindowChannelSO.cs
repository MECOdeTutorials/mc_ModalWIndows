using UnityEngine;
using UnityEngine.Events;

namespace SO
{
    [CreateAssetMenu(fileName = "ModalWindowChannel", menuName = "Channels/ModalWindow")]
    public class ModalWindowChannelSO : ScriptableObject
    {
        public UnityAction<string, UnityAction<ModalWindowResponseEnum>> OnRequestModalWindow;

        public void RaiseOnRequestModal(string key, UnityAction<ModalWindowResponseEnum> action)
        {
            if (OnRequestModalWindow != null)
            {
                OnRequestModalWindow.Invoke(key, action);
            }
            else
            {
                Debug.LogError("RequestModalWindow has no listeners!");
            }
        }
    }
}
