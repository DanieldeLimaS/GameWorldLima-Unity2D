using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ProximoLevelPoint : MonoBehaviour
{
    public string levelName;
    void OnCollisionEnter2D(Collision2D col) 
    {

        if (col.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(levelName);
        }
    }
}
