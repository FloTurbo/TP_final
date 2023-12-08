using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

/* hit box
 * sortir écran full screnn */

public class affichageEtScore : MonoBehaviour
{
    //varibales d'affichage
    public TextMeshProUGUI gameOver;
    public TextMeshProUGUI affScore;
    public TextMeshProUGUI affInfosPartie;
    public TextMeshProUGUI affTempsRestant;
    public TextMeshProUGUI affNiveauManche;
    public TextMeshProUGUI btnRecommencerText;
    public TextMeshProUGUI btnMenuText;
    public Button recommencer;
    public Button menu;
    private static float tempsActuel = 0f;
    private static float tempsDepart;
    public static bool messageFinDejaAff = false;

    //variables pour score
    public static int nbMeteoriteDetruites = 0;
    public static int nbVaisseauxDetruits = 0;
    int nbPoints = 0;
    int dureePartie;
    public static bool joueurMort = false;
    private static int numManche;
    private static int numNiveau ;
    private static int numNiveauRef = 0;
    



    // variables pour vérifier si le joueur passe au prochin niveau
    public static int nbTotalVaisseauxEnnemisDetruits = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        //intanciation du numéro de la manche en fonction du nombre d'ennemis par vague
        if (generationEnnemis.nbEnnmisVaguesRef == 2)
        {
            numManche = 1;
        }
        if (generationEnnemis.nbEnnmisVaguesRef == 3)
        {
            numManche = 2;
        }
        if (generationEnnemis.nbEnnmisVaguesRef == 5)
        {
            numManche = 3;
        }
        if (generationEnnemis.nbEnnmisVaguesRef == 6)
        {
            numManche = 4;
        }

        //affichage du parcours
        if (numNiveauRef == 0) /* si il s'agit de la première moi que ce script est appelé */
        {
            numNiveau = 1;
            numNiveauRef = 1;
            tempsDepart = 45f;
        }
        
        affNiveauManche.text = "manche : " + numManche + " / niveau : " + numNiveau;


        //reset le temps actuel à 0 et les différentes variables des points
        nbMeteoriteDetruites = 0;
        nbVaisseauxDetruits = 0;

        // gestion des bouttons
        menu.enabled = false;
        recommencer.enabled = false;
        gameOver.enabled = false;

        //instanciation du timer
        tempsActuel = tempsDepart;
        affTempsRestant.text = "temps restant : " + tempsActuel.ToString("0");
    }

    // Update is called once per frame
    void Update()
    {
        /* NIVEAU ET MANCHE */
        //modifie si il y a un changement
        if (numNiveauRef != numNiveau)
        {
            numNiveauRef = numNiveau;
            affNiveauManche.text = "manche : " + numManche + " / niveau : " + numNiveau;
        }

        //affNiveauManche.text = "manche : " + numManche + " / niveau : " + numNiveau;

        /* TEMPS */

        //enlève 1 seconde
        if (messageFinDejaAff == false) 
        {
            tempsActuel -= 1 * Time.deltaTime;
            affTempsRestant.text = "Temps restant: " + tempsActuel.ToString("0"); /* affiche le nouveau temps */
        }

        //vérifie si il arrive au bout du temps apparti
        //if (tempsActuel == 0)
        //{
        //    //le message de fin sera afficher
        //    messageFinDejaAff = true;

        //    //instanciation de la durée de la partie
        //    dureePartie = (int)tempsDepart;

        //    //afiche le message de game over
        //    gameOver.text = "game over";

        //    gameOver.enabled = true;

        //    //appel à la fonction qui affiche les informations de fin de jeu
        //    Invoke("messageFin", 1f);
        //}

        /* SCORE */

        calculerScore(); /* appel à la méthode qui calcul le score */

        //affichage du score
        affScore.text = "score : " + nbPoints;

        /* SI LE JOUEUR EST MORT */

        if (joueurMort == true && messageFinDejaAff == false)
        {
            //le message de fin sera afficher
            messageFinDejaAff = true;

            //instanciation de la durée de la partie
            dureePartie = (int)(tempsDepart - tempsActuel);

            affTempsRestant.text = "Temps restant: 0";
            //afiche le message de game over et le faire clignoter
            gameOver.text = "game over";

            gameOver.enabled = true;
            gameOver.enabled = false;
            gameOver.enabled = true;
            gameOver.enabled = false;
            gameOver.enabled = true;


            //appel à la fonction qui affiche les informations de fin de jeu
            Invoke("messageFin", 1f);
        }

        /* RÉUSSITE DU JEU */ 

        //vérifie si tout les ennemis ont été détruits
        if(((nbTotalVaisseauxEnnemisDetruits == (generationEnnemis.nbEnnmisVaguesRef * 6)) || tempsActuel <= 0 ) && messageFinDejaAff == false)
        {

            //le message de fin de réussite s'affiche pendant 1s
            messageFinDejaAff=true;

            //message
            gameOver.text = "succes";
            gameOver.enabled = true;

            //appel à la fonction qui affiche les informations de fin de jeu
            Invoke("messageReussite", 1f);
        }

    }

    void messageReussite() /* méthode qui affiche le message de réussite */
    {
        // enlever le message et les informations affichées
        gameOver.enabled = false;
        affScore.enabled = false;
        affTempsRestant.enabled = false;

        Debug.Log("-----------------------");
        Debug.Log("NIVEAU " + numNiveau);
        Debug.Log("-----------------------");

        //incrémentation du nombre d'obstacles et du numéro de niveau et de manche si le niveau 4 vient d'être complété
        if (numNiveau == 1)
        {
            numNiveau++; /* incérmetation */
            tempsDepart = 35f;
            genereObstacles.nbObstaclesRef += 4; /* ajout de 2 obtacles */

            numNiveauRef = numNiveau;
            affNiveauManche.text = "manche : " + numManche + " / niveau : " + numNiveau;

            //appel de la méthode qui charge le jeu
            rechargerScene();
        }else if (numNiveau == 2)
        {
            numNiveau++; /* incérmetation */
            tempsDepart = 25f;
            genereObstacles.nbObstaclesRef += 2; /* ajout de 2 obtacles */

            numNiveauRef = numNiveau;
            affNiveauManche.text = "manche : " + numManche + " / niveau : " + numNiveau;

            //appel de la méthode qui charge le jeu
            rechargerScene();

        }else if (numNiveau == 3)
        {
            numNiveau++; /* incérmetation */
            tempsDepart = 15f;
            genereObstacles.nbObstaclesRef += 2; /* ajout de 2 obtacles */

            numNiveauRef = numNiveau;
            affNiveauManche.text = "manche : " + numManche + " / niveau : " + numNiveau;

            //appel de la méthode qui charge le jeu
            rechargerScene();

        }else if (numNiveau == 4)
        {
            numNiveau = 1; /* incérmetation */
            numManche++; /* incrémentation */
            tempsDepart = 45f;
            genereObstacles.nbObstaclesRef = 4; /* ajout de 2 obtacles */

            //définition du nombre d'ennemis en fonciton de la manche
            if (numManche == 1)
            {
                generationEnnemis.nbEnnmisVaguesRef = 2;
            }

            if (numManche == 2)
            {
                generationEnnemis.nbEnnmisVaguesRef = 3;
            }

            if (numManche == 3)
            {
                generationEnnemis.nbEnnmisVaguesRef = 5;
            }

            if (numManche == 4)
            {
                generationEnnemis.nbEnnmisVaguesRef = 6;
            }

            //affichage
            numNiveauRef = numNiveau;
            affNiveauManche.text = "manche : " + numManche + " / niveau : " + numNiveau;

            

            //appel de la méthode qui charge le jeu
            rechargerScene();

        }

        Debug.Log("-----------------------");
        Debug.Log("nb obstacles " + genereObstacles.nbObstaclesRef);
        Debug.Log("-----------------------");
    }

    void messageFin() /* fonction qui affiche le message de fin de jeu */
    {
        // enlever le message de gameOver et les informations affichées
        gameOver.enabled = false;
        affScore.enabled = false;
        affTempsRestant.enabled = false;
        nbTotalVaisseauxEnnemisDetruits = 0;

        //repart du niveau 1 de la manche
        numNiveau = 1; /* incérmetation */
        tempsDepart = 45f;
        genereObstacles.nbObstaclesRef = 4; /* ajout de 2 obtacles */

        //afficher les boutons 
        btnMenuText.text = "menu";
        btnRecommencerText.text = "recommencer";

        //activer les boutonsj
        menu.enabled = true;
        recommencer.enabled = true;

        /* AFFICHAGE DU SCORE */

        affInfosPartie.text = "nombre de météorites détruites : " + nbMeteoriteDetruites +
                               "\nnombre de vaisseaux ennemis détuites : " + nbVaisseauxDetruits +
                               "\nnombre de points gagnés : " + nbPoints +
                               "\ndurée de la partie : " + dureePartie +" seconde(s)";
    }

    void calculerScore() /* méthode qui calcul le score */
    {
        //calcul
        nbPoints = 30 * nbVaisseauxDetruits + 10 * nbMeteoriteDetruites;
    }

    //méthode pour changer de scène
    public void rechargerScene()
    {
        messageFinDejaAff = false;
        joueurMort = false;
        nbTotalVaisseauxEnnemisDetruits = 0;


        //appel la scène désirée
        SceneManager.LoadScene("scene_jeu");

    }
}
