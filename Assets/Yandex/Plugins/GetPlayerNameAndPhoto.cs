using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;
using UnityEngine.Networking;

public class GetPlayerNameAndPhoto : MonoBehaviour
{
    [SerializeField] private Text _playerName;
    [SerializeField] private RawImage _playerIcon;
    private Coroutine _coroutine;

    private void Awake()
    {
        _playerName = GetComponentInChildren<Text>();
        _playerIcon = GetComponentInChildren<RawImage>();
        if(YandexGame.SDKEnabled == true)
        {
            GetPlayerInfo();
        }
    }

    private void OnEnable()
    {
        YandexGame.GetDataEvent += GetPlayerInfo;
    }

    private void OnDisable()
    {
        YandexGame.GetDataEvent -= GetPlayerInfo;
    }

    private void GetPlayerInfo()
    {
        try 
        {
            if (YandexGame.SDKEnabled && YandexGame.auth)
            {
                SetName(YandexGame.playerName);
                SetIcon(YandexGame.playerPhoto);
            }
        }

        catch(System.Exception error) 
        {
            Debug.LogError(error.Message);
            _playerName.gameObject.SetActive(false);
            _playerIcon.gameObject.SetActive(false);
        }
    }

    private void SetName(string name)
    {
        _playerName.text = name;
    }

    private void SetIcon(string url)
    {
        _coroutine = StartCoroutine(DownloadImage(url));
    }

    private IEnumerator DownloadImage(string url)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
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
