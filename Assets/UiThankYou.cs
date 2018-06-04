using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiThankYou : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(BackToMain());
	}

    private IEnumerator BackToMain()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
