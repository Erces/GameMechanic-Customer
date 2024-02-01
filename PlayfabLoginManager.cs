using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
public class PlayfabLoginManager : MonoBehaviour
{
    public TMP_Text messageText;
    public InputField emailInput;
    public InputField passwordInput;

    public GameObject canvas;

    public void OnError(PlayFabError error)
    {
        Debug.Log(error);
        messageText.text = error.ToString();
    }

    #region Register
    public void RegisterButton()
    {
        var req = new RegisterPlayFabUserRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false

        };
        PlayFabClientAPI.RegisterPlayFabUser(req, OnRegisterSuccess, OnError);

    }

    public void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        messageText.text = "Registered and logged in!";
        Invoke("RemoveCanvas", 1.5f);

    }
    #endregion

    public void LoginButton()
    {
        var req = new LoginWithEmailAddressRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(req, OnLoginSuccess, OnError);
    }

    public void OnLoginSuccess(LoginResult result)
    {
        messageText.text = "Successful login!";
        Invoke("RemoveCanvas", 1.5f);
    }
    public void RemoveCanvas()

    {
        canvas.SetActive(false);
    }
    



}
