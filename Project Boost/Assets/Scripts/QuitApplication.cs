using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitApplication : MonoBehaviour
{
   void Update()
   {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }     
   }
}
