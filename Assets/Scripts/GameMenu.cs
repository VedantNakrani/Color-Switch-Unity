using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour {

    public void QuitGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
