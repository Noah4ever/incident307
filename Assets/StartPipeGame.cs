using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPipeGame : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Starting Pipe Game");    
        SceneManager.LoadScene("PipeGame");
    }

    public bool CanInteract()
    {
        return true;
    }
}