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
    private bool messageFinDejaAff = false;

    //variables pour score
    public static int nbMeteoriteDetruites = 0;
    public static int nbVaisseauxDetruits = 0;
    int nbPoints = 0;
    int dureePartie;
    public static bool joueurMort = false;


    // Start is called before the first frame update
    void Start()
    {
        // gestion des bouttons
        //menu.GetComponent<TextMeshProUGUI>().enabled = false;
        //recommencer.GetComponent<TextMeshProUGUI>().enabled = false;
        menu.enabled = false;
        recommencer.enabled = false;
        //gameOver.enabled = false;

        //instanciation du timer
        tempsActuel = tempsDepart;
        affTempsRestant.text = "temps restant : " + tempsActuel.ToString("0");
    }

    // Update is called once per frame
    void Update()
    {
        /* TEMPS */

        //enlève 1 seconde
        if(messageFinDejaAff == false) 
        {
            tempsActuel -= 1 * Time.deltaTime;
            affTempsRestant.text = "Temps restant: " + tempsActuel.ToString("0"); /* affiche le nouveau temps */
        }

        //vérifie si il arrive au bout du temps apparti
        if (tempsActuel == 0 && messageFinDejaAff == false)
        {
            //le message de fin sera afficher
            messageFinDejaAff = true;

            //instanciation de la durée de la partie
            dureePartie = (int)tempsDepart;

            //afiche le message de game over
            gameOver.enabled = true;

            //appel à la fonction qui affiche les informations de fin de jeu
            Invoke("messageFin", 1f);
        }

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
            gameOver.enabled = true;
            gameOver.enabled = false;
            gameOver.enabled = true;
            gameOver.enabled = false;
            gameOver.enabled = true;


            //appel à la fonction qui affiche les informations de fin de jeu
            Invoke("messageFin", 1f);
        }
    }

    void messageFin() /* fonction qui affiche le message de fin de jeu */
    {
        // enlever le message de gameOver et les inoformations affichées
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
}
