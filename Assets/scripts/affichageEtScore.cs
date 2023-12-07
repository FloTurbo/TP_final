using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;


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
    private float tempsActuel = 0f;
    public float tempsDepart = 90f;
    public static bool messageFinDejaAff = false;

    //variables pour score
    public static int nbMeteoriteDetruites = 0;
    public static int nbVaisseauxDetruits = 0;
    int nbPoints = 0;
    int dureePartie;
    public static bool joueurMort = false;
    private int numManche;
    private int numNiveau = 1;
    private int numNiveauRef = 1;



    // variables pour v�rifier si le joueur passe au prochin niveau
    public static int nbTotalVaisseauxEnnemisDetruits = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        //intanciation du num�ro de la manche en fonction du nombre d'ennemis par vague
        if (genereEnnemis.nbEnnmisVaguesRef == 2)
        {
            numManche = 1;
        }
        if (genereEnnemis.nbEnnmisVaguesRef == 3)
        {
            numManche = 2;
        }
        if (genereEnnemis.nbEnnmisVaguesRef == 5)
        {
            numManche = 3;
        }
        if (genereEnnemis.nbEnnmisVaguesRef == 6)
        {
            numManche = 4;
        }

        //affichage de parcours
        affNiveauManche.text = "manche : " + numManche + " / niveau : " + numNiveau;

        //reset le temps actuiel � 0 et les diff�rentes variables des points
        tempsActuel = 0;
        nbMeteoriteDetruites = 0;
        nbVaisseauxDetruits = 0;
        nbPoints = 0;

        // gestion des bouttons
        //menu.GetComponent<TextMeshProUGUI>().enabled = false;
        //recommencer.GetComponent<TextMeshProUGUI>().enabled = false;
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
      

        /* TEMPS */

        //enl�ve 1 seconde
        if(messageFinDejaAff == false) 
        {
            tempsActuel -= 1 * Time.deltaTime;
            affTempsRestant.text = "Temps restant: " + tempsActuel.ToString("0"); /* affiche le nouveau temps */
        }

        //v�rifie si il arrive au bout du temps apparti
        if (tempsActuel == 0)
        {
            //le message de fin sera afficher
            messageFinDejaAff = true;

            //instanciation de la dur�e de la partie
            dureePartie = (int)tempsDepart;

            //afiche le message de game over
            gameOver.text = "game over";

            gameOver.enabled = true;

            //appel � la fonction qui affiche les informations de fin de jeu
            Invoke("messageFin", 1f);
        }

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
        if((nbTotalVaisseauxEnnemisDetruits == (genereEnnemis.nbEnnmisVaguesRef * 6)) && messageFinDejaAff == false)
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

        //incr�mentation du nombre d'obstacles et du num�ro de niveau et de manche si le niveau 4 vient d'�tre compl�t�
        if (numNiveau == 1)
        {
            numNiveau++; /* inc�rmetation */
            genereObstacles.nbObstaclesRef += 2; /* ajout de 2 obtacles */

            //appel de la m�thode qui charge le jeu
            rechargerScene();
        }
        if (numNiveau == 2)
        {
            numNiveau++; /* inc�rmetation */
            genereObstacles.nbObstaclesRef += 2; /* ajout de 2 obtacles */

            //appel de la m�thode qui charge le jeu
            rechargerScene();

        }
        if (numNiveau == 3)
        {
            numNiveau++; /* inc�rmetation */
            genereObstacles.nbObstaclesRef += 2; /* ajout de 2 obtacles */

            //appel de la m�thode qui charge le jeu
            rechargerScene();

        }
        if (numNiveau == 4)
        {
            numNiveau = 1; /* inc�rmetation */
            genereObstacles.nbObstaclesRef = 4; /* ajout de 2 obtacles */

            //appel de la m�thode qui charge le jeu
            rechargerScene();

        }
    }

    void messageFin() /* fonction qui affiche le message de fin de jeu */
    {
        // enlever le message de gameOver et les informations affich�es
        gameOver.enabled = false;
        affScore.enabled = false;
        affTempsRestant.enabled = false;
       

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
