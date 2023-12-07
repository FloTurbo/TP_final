using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btnAcceuil : MonoBehaviour
{
    //méthode pour changer de scène
    public void changerScene()
    {
        //appel la scène désirée
        SceneManager.LoadScene("sceneAcceuil");

    }
}
