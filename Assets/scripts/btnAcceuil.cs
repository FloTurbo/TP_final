using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btnAcceuil : MonoBehaviour
{
    //m�thode pour changer de sc�ne
    public void changerScene()
    {
        //appel la sc�ne d�sir�e
        SceneManager.LoadScene("sceneAcceuil");

    }
}
