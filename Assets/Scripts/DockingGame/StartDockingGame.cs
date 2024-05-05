using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartDockingGame : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        SceneManager.LoadScene("DockingGame");
    }

    public bool CanInteract()
    {
        return true;
    }
}