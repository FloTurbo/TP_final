using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Security.Cryptography.X509Certificates;

public class btnRecommencer : MonoBehaviour
{
    //m�thode pour changer de sc�ne
    public void changerSceneEnCours()
    {
        affichageEtScore.messageFinDejaAff = false;
        affichageEtScore.joueurMort = false;


        //appel la sc�ne d�sir�e
        SceneManager.LoadScene("scene_jeu");

    }
}
