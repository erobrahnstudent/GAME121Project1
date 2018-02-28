using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenechangescript : MonoBehaviour {
	public void scenechange(string scene)
    {
        if (scene == "qqq") Application.Quit();
        else SceneManager.LoadScene(scene);
    }
}
