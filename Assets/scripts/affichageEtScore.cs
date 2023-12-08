using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

/* hit box
 * sortir �cran full screnn */

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
    



    // variables pour v�rifier si le joueur passe au prochin niveau
    public static int nbTotalVaisseauxEnnemisDetruits = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        //intanciation du num�ro de la manche en fonction du nombre d'ennemis par vague
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
        if (numNiveauRef == 0) /* si il s'agit de la premi�re moi que ce script est appel� */
        {
            numNiveau = 1;
            numNiveauRef = 1;
            tempsDepart = 45f;
        }
        
        affNiveauManche.text = "manche : " + numManche + " / niveau : " + numNiveau;


        //reset le temps actuel � 0 et les diff�rentes variables des points
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

        //enl�ve 1 seconde
        if (messageFinDejaAff == false) 
        {
            tempsActuel -= 1 * Time.deltaTime;
            affTempsRestant.text = "Temps restant: " + tempsActuel.ToString("0"); /* affiche le nouveau temps */
        }

        //v�rifie si il arrive au bout du temps apparti
        //if (tempsActuel == 0)
        //{
        //    //le message de fin sera afficher
        //    messageFinDejaAff = true;

        //    //instanciation de la dur�e de la partie
        //    dureePartie = (int)tempsDepart;

        //    //afiche le message de game over
        //    gameOver.text = "game over";

        //    gameOver.enabled = true;

        //    //appel � la fonction qui affiche les informations de fin de jeu
        //    Invoke("messageFin", 1f);
        //}

        /* SCORE */

        calculerScore(); /* appel � la m�thode qui calcul le score */

        //affichage du score
        affScore.text = "score : " + nbPoints;

        /* SI LE JOUEUR EST MORT */

        if (joueurMort == true && messageFinDejaAff == false)
        {
            //le message de fin sera afficher
            messageFinDejaAff = true;

            //instanciation de la dur�e de la partie
            dureePartie = (int)(tempsDepart - tempsActuel);

            affTempsRestant.text = "Temps restant: 0";
            //afiche le message de game over et le faire clignoter
            gameOver.text = "game over";

            gameOver.enabled = true;
            gameOver.enabled = false;
            gameOver.enabled = true;
            gameOver.enabled = false;
            gameOver.enabled = true;


            //appel � la fonction qui affiche les informations de fin de jeu
            Invoke("messageFin", 1f);
        }

        /* R�USSITE DU JEU */ 

        //v�rifie si tout les ennemis ont �t� d�truits
        if(((nbTotalVaisseauxEnnemisDetruits == (generationEnnemis.nbEnnmisVaguesRef * 6)) || tempsActuel <= 0 ) && messageFinDejaAff == false)
        {

            //le message de fin de r�ussite s'affiche pendant 1s
            messageFinDejaAff=true;

            //message
            gameOver.text = "succes";
            gameOver.enabled = true;

            //appel � la fonction qui affiche les informations de fin de jeu
            Invoke("messageReussite", 1f);
        }

    }

    void messageReussite() /* m�thode qui affiche le message de r�ussite */
    {
        // enlever le message et les informations affich�es
        gameOver.enabled = false;
        affScore.enabled = false;
        affTempsRestant.enabled = false;

        Debug.Log("-----------------------");
        Debug.Log("NIVEAU " + numNiveau);
        Debug.Log("-----------------------");

        //incr�mentation du nombre d'obstacles et du num�ro de niveau et de manche si le niveau 4 vient d'�tre compl�t�
        if (numNiveau == 1)
        {
            numNiveau++; /* inc�rmetation */
            tempsDepart = 35f;
            genereObstacles.nbObstaclesRef += 4; /* ajout de 2 obtacles */

            numNiveauRef = numNiveau;
            affNiveauManche.text = "manche : " + numManche + " / niveau : " + numNiveau;

            //appel de la m�thode qui charge le jeu
            rechargerScene();
        }else if (numNiveau == 2)
        {
            numNiveau++; /* inc�rmetation */
            tempsDepart = 25f;
            genereObstacles.nbObstaclesRef += 2; /* ajout de 2 obtacles */

            numNiveauRef = numNiveau;
            affNiveauManche.text = "manche : " + numManche + " / niveau : " + numNiveau;

            //appel de la m�thode qui charge le jeu
            rechargerScene();

        }else if (numNiveau == 3)
        {
            numNiveau++; /* inc�rmetation */
            tempsDepart = 15f;
            genereObstacles.nbObstaclesRef += 2; /* ajout de 2 obtacles */

            numNiveauRef = numNiveau;
            affNiveauManche.text = "manche : " + numManche + " / niveau : " + numNiveau;

            //appel de la m�thode qui charge le jeu
            rechargerScene();

        }else if (numNiveau == 4)
        {
            numNiveau = 1; /* inc�rmetation */
            numManche++; /* incr�mentation */
            tempsDepart = 45f;
            genereObstacles.nbObstaclesRef = 4; /* ajout de 2 obtacles */

            //d�finition du nombre d'ennemis en fonciton de la manche
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

            

            //appel de la m�thode qui charge le jeu
            rechargerScene();

        }

        Debug.Log("-----------------------");
        Debug.Log("nb obstacles " + genereObstacles.nbObstaclesRef);
        Debug.Log("-----------------------");
    }

    void messageFin() /* fonction qui affiche le message de fin de jeu */
    {
        // enlever le message de gameOver et les informations affich�es
        gameOver.enabled = false;
        affScore.enabled = false;
        affTempsRestant.enabled = false;
        nbTotalVaisseauxEnnemisDetruits = 0;

        //repart du niveau 1 de la manche
        numNiveau = 1; /* inc�rmetation */
        tempsDepart = 45f;
        genereObstacles.nbObstaclesRef = 4; /* ajout de 2 obtacles */

        //afficher les boutons 
        btnMenuText.text = "menu";
        btnRecommencerText.text = "recommencer";

        //activer les boutonsj
        menu.enabled = true;
        recommencer.enabled = true;

        /* AFFICHAGE DU SCORE */

        affInfosPartie.text = "nombre de m�t�orites d�truites : " + nbMeteoriteDetruites +
                               "\nnombre de vaisseaux ennemis d�tuites : " + nbVaisseauxDetruits +
                               "\nnombre de points gagn�s : " + nbPoints +
                               "\ndur�e de la partie : " + dureePartie +" seconde(s)";
    }

    void calculerScore() /* m�thode qui calcul le score */
    {
        //calcul
        nbPoints = 30 * nbVaisseauxDetruits + 10 * nbMeteoriteDetruites;
    }

    //m�thode pour changer de sc�ne
    public void rechargerScene()
    {
        messageFinDejaAff = false;
        joueurMort = false;
        nbTotalVaisseauxEnnemisDetruits = 0;


        //appel la sc�ne d�sir�e
        SceneManager.LoadScene("scene_jeu");

    }
}
