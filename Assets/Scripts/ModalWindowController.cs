using System;
using System.Collections;
using System.Collections.Generic;
using SO;
using UnityEngine;
using UnityEngine.Events;

public class ModalWindowController : MonoBehaviour
{
    // Scene references
    [SerializeField] private GameObject canvas;
    [SerializeField] private ModalWindow modalWindow;

    [Header("Channels")] 
    [SerializeField] private ModalWindowChannelSO modalWindowChannelSo;

    [Space] [Header("Modal windows")] 
    [SerializeField] private ModalWindowDataSO[] modalWindowsDataRaw;

    private Dictionary<string, ModalWindowDataSO> _modalWindowData;

    private void Start()
    {
        // Subscribe a listener to the action
        modalWindowChannelSo.OnRequestModalWindow += RequestModalWindow;
        
        DontDestroyOnLoad(canvas);
        DontDestroyOnLoad(this);
        
        modalWindow.gameObject.SetActive(false);

        InitDictionary();
    }

    /// <summary>
    /// Move the windows inside the dictionary to access it by key
    /// </summary>
    private void InitDictionary()
    {
        _modalWindowData = new Dictionary<string, ModalWindowDataSO>();

        foreach (var mwd in modalWindowsDataRaw)
        {
            if (_modalWindowData.ContainsKey(mwd.key))
            {
                Debug.LogErrorFormat("Key {0} duplicated! Skipping it...", mwd.key);
            }
            else
            {
                _modalWindowData.Add(mwd.key, mwd);
            }
        }
        
        // Then free the array
        modalWindowsDataRaw = null;
    }

    /// <summary>
    /// Request the modal opening with the requested data
    /// </summary>
    /// <param name="key">What set of data pick from the stored ones</param>
    public void RequestModalWindow(string key, UnityAction<ModalWindowResponseEnum> action)
    {
        if (_modalWindowData.ContainsKey(key))
        {
                modalWindow.Show(_modalWindowData[key], action);
                return;
        }
        
        // If we reach here, the key was not found in the dictionary
        Debug.LogErrorFormat("Modal Window Controller has no data for {0} key", key);
    }

    private void OnDestroy()
    {
        // Unsubscribe the listener from the action
        modalWindowChannelSo.OnRequestModalWindow -= RequestModalWindow;
    }
}
