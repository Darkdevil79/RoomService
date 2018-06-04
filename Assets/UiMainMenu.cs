using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiMainMenu : MonoBehaviour {

    public void OpenFoodMenu()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }


}
