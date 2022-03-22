using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextLevelLoader : MonoBehaviour
{
    [SerializeField] private UiManager ui;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ui.FinishReached();
        }
    }

}
