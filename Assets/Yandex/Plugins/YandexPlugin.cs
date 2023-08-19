using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

public class YandexPlugin : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _playerName;
    [SerializeField] private RawImage _playerIcon;
    private Coroutine _coroutine;

    [DllImport("__Internal")] private static extern void GiveMePlayerData();

    public void Start()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
        GiveMePlayerData();
#endif
    }

    public void SetName(string name)
    {
        _playerName.text = name;
    }

    public void SetIcon(string url)
    {
        _coroutine = StartCoroutine(DownloadImage(url));
    }

    private IEnumerator DownloadImage(string url)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();
        if(request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(request.error);
        }
        else
        {
            _playerIcon.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            StopCoroutine(_coroutine);
        }
    }
}
