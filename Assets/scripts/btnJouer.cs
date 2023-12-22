using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class btnJouer : MonoBehaviour
{
    //variable pourla s�lection de la sc�ne
    private Button dernierBoutonSelectionne;
   // public affichageEtScore sceneJeuRef;
   // public genereEnnemis ennemisSceneRef;
    //public genereObstacles obstacelsSceneRef;

    // Start is called before the first frame update
    void Start()
    {
        //d�sactiv� tout les scripts de manches
        

        // g�n�ration d'un tableau des boutons utilis�
        Button[] boutons = FindObjectsOfType<Button>();

        foreach (Button bouton in boutons)
        {
            bouton.onClick.AddListener(() => BoutonClique(bouton));
        }
    }

    void BoutonClique(Button bouton)
    {
        //v�rifier si le boutons correspond � un boutons de manches
        if(bouton.name == "manche1" || bouton.name == "manche2"||bouton.name == "manche3"|| bouton.name == "manche4" )
        {
            dernierBoutonSelectionne = bouton; /* si oui, ajout comme �tant le dernier bouton s�lectionn� */
        }

    }

    public void onBtnPlayClic() /* quand le bouton play est s�lectionn� */
    {
        //r�cup�rer la manche s�lectionn�e
        Button mancheVoulue = dernierBoutonSelectionne;

        //d�finition du nombre d'ennemis en fonciton de la manche
        if (mancheVoulue.name == "manche1")
        {
            generationEnnemis.nbEnnmisVaguesRef = 2;
        }

        if (mancheVoulue.name == "manche2")
        {
            generationEnnemis.nbEnnmisVaguesRef = 3;
        }

        if (mancheVoulue.name == "manche3")
        {
            generationEnnemis.nbEnnmisVaguesRef = 5;
        }

        if (mancheVoulue.name == "manche4")
        {
            generationEnnemis.nbEnnmisVaguesRef = 6;
        }

        //appel � la fonction qui change les sc�nes
        changerScene();
       
    }

    //m�thode pour changer de sc�ne
    public void changerScene()
    {
        affichageEtScore.messageFinDejaAff = false;
        affichageEtScore.joueurMort = false;


        //appel la sc�ne d�sir�e
        SceneManager.LoadScene("scene_jeu");

    }

    // Update is called once per frame
    void Update()
    {

    }

}




