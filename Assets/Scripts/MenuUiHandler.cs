using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUiHandler : MonoBehaviour
{
    public TextMeshProUGUI input;
    public void StartGame() {
        if (DataManager.Instance != null) {
            DataManager.Instance.PlayerName = input.text;
        }
        SceneManager.LoadScene(1);
    }
}
