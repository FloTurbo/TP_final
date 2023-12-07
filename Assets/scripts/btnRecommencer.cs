using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Security.Cryptography.X509Certificates;

public class btnRecommencer : MonoBehaviour
{
    //méthode pour changer de scène
    public void changerSceneEnCours()
    {
        affichageEtScore.messageFinDejaAff = false;
        affichageEtScore.joueurMort = false;


        //appel la scène désirée
        SceneManager.LoadScene("scene_jeu");

    }
}
