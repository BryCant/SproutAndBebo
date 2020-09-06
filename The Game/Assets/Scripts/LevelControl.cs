using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class LevelControl : MonoBehaviour
{
    public string sceneName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("TransitionPoint"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }

}
