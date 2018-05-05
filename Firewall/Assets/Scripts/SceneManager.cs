using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneManager : MonoBehaviour {

	public void LoadScene(int buildNum)
    {
        Application.LoadLevel(buildNum);
    }
    
}
