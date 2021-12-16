using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger : MonoBehaviour
{
    public BoxHandler boxHandler;
    private void OnTriggerEnter()
    {
        boxHandler.GiveLetter();
    }
}
