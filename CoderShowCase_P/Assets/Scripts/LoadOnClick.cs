using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOnClick : MonoBehaviour {

    public void LoadScene(int level)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(level);
    }
}
