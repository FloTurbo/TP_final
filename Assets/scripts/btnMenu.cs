using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Security.Cryptography.X509Certificates;

public class btnMenu : MonoBehaviour
{
    //méthode pour changer de scène
    public void changerScene()
    {
        //appel la scène désirée
        SceneManager.LoadScene("Scene_menu");

    }
}
