using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class btnJouer : MonoBehaviour
{
    //variable pourla sélection de la scène
    private Button dernierBoutonSelectionne;
   // public affichageEtScore sceneJeuRef;
   // public genereEnnemis ennemisSceneRef;
    //public genereObstacles obstacelsSceneRef;

    // Start is called before the first frame update
    void Start()
    {
        //désactivé tout les scripts de manches
        

        // génération d'un tableau des boutons utilisé
        Button[] boutons = FindObjectsOfType<Button>();

        foreach (Button bouton in boutons)
        {
            bouton.onClick.AddListener(() => BoutonClique(bouton));
        }
    }

    void BoutonClique(Button bouton)
    {
        //vérifier si le boutons correspond à un boutons de manches
        if(bouton.name == "manche1" || bouton.name == "manche2"||bouton.name == "manche3"|| bouton.name == "manche4" )
        {
            dernierBoutonSelectionne = bouton; /* si oui, ajout comme étant le dernier bouton sélectionné */
        }

    }

    public void onBtnPlayClic() /* quand le bouton play est sélectionné */
    {
        //récupérer la manche sélectionnée
        Button mancheVoulue = dernierBoutonSelectionne;

        //définition du nombre d'ennemis en fonciton de la manche
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

        //appel à la fonction qui change les scènes
        changerScene();
       
    }

    //méthode pour changer de scène
    public void changerScene()
    {
        affichageEtScore.messageFinDejaAff = false;
        affichageEtScore.joueurMort = false;


        //appel la scène désirée
        SceneManager.LoadScene("scene_jeu");

    }

    // Update is called once per frame
    void Update()
    {

    }

}




