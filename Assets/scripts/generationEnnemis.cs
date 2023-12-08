using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generationEnnemis : MonoBehaviour
{
    //variables
    public GameObject ennemi;
    public static int nbEnnmisVaguesRef;
    private int nbEnnemisVague = 2;
    public float tempsEntreVagues = 2f;
    public float maxPosY = 2.2f;
    public float minPosY = -2.2f;

    // Start is called before the first frame update
    void Start()
    {
        //vérifie si le nombre d'ennemis par vague a été modifier
        if (nbEnnmisVaguesRef != 0)
        {
            nbEnnemisVague = nbEnnmisVaguesRef;
        }

        //génère les ennemis
        InvokeRepeating("instacierEnnemi", 0f, tempsEntreVagues);

        //arrête tous les invokes apres le temps désigné
        Invoke("stop", 12);
    }

    // Update is called once per frame
    void Update()
    {
        //modifie si il y a un changement
        if (nbEnnmisVaguesRef != nbEnnemisVague)
        {
            nbEnnemisVague = nbEnnmisVaguesRef;
        }
    }

    private void instacierEnnemi()
    {
        //random une position y
        float y = UnityEngine.Random.Range(-2.7f, 2.7f);

        //boucle qui instancie les ennemis en fonction du nombre par vagues
        for (int i = 0; i < nbEnnemisVague; i++)
        {
            //si la variable y est inférieur à 2
            if (y < 2)
            {
                y++; /*incrémente */
            }
            else if (y > -2)
            {
                y--; /* décrémente */
            }
            //vairable pour la position de l'ennemi
            Vector3 pos = new Vector3(6, y, 0);

            //incatanier
            Instantiate(ennemi, pos, Quaternion.identity);
        }
    }

    private void stop()
    {
        //met fin aux prossesues invoke
        CancelInvoke("instacierEnnemi");
    }
}
