using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogInSystem : MonoBehaviour
{
    public InputField email;
    public InputField password;

    public Text outputText;

    void Start()
    {
        FirebaseAuthManager.Instance.LoginState += OnChangedState;
        FirebaseAuthManager.Instance.Init();
    }

    private void OnChangedState(bool sign)
    {
        outputText.text = sign ? "�α��� : " : "�α׾ƿ� : ";
        outputText.text += FirebaseAuthManager.Instance.UserId;
    }

    public void Create()
    {
        string e = email.text;
        string p = password.text;

        FirebaseAuthManager.Instance.Create(e, p);
    }

    public void Login()
    {
        FirebaseAuthManager.Instance.Login(email.text, password.text);
    }

    public void LogOut()
    {
        FirebaseAuthManager.Instance.LogOut();
    }
}
