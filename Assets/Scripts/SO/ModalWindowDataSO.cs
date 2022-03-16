using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = "ModalWindow", menuName = "Utility/ModalWindow")]
    public class ModalWindowDataSO : ScriptableObject
    {
        public string key;
        
        public string title;
        public string content;
        
        public bool hasConfirmButton;
        public bool hasActionButton;
        public bool hasDeclineButton;
        
        public string confirmBtnText;
        public string actionBtnText;
        public string declineBtnText;
    }
}
