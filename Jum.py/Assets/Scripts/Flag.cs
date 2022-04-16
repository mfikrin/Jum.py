using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flag : MonoBehaviour
{
    public string nextSceneName;
    public bool lastLevel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (lastLevel)
            {
                SceneManager.LoadScene("Menu");

            }
            else
            {
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }
}
