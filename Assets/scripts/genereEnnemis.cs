using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class genereEnnemis : MonoBehaviour
{
    //variables
    public GameObject ennemi;
    public float nbEnnemisVague;
    public float tempsEntreVagues = 6f;
    public float nbEnnemis;
    public float maxPosY;
    public float minPosY;


    // Start is called before the first frame update
    void Start()
    {
        //g�n�re les ennemis
        InvokeRepeating("instacierEnnemi", 0f, tempsEntreVagues);

        //arr�te tous les invokes apres le temps d�sign�
        Invoke("stop", 12);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void instacierEnnemi()
    {
        //random une position y
        float y = UnityEngine.Random.Range(-2.7f, 2.7f);

        //boucle qui instancie les ennemis en fonction du nombre par vagues
        for (int i = 0; i < nbEnnemisVague; i++)
        {
            //si la variable y est inf�rieur � 2
            if( y < 2)
            {
                y++; /*incr�mente */
            }
            else if( y > -2)
            {
                y--; /* d�cr�mente */
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
