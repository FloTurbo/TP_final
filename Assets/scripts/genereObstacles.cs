using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class genereObstacles : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject meteorite1;
    public GameObject meteorite2;
    public GameObject meteorite3;
    public GameObject mine;
    public float tempsEntreVagues = 2f;
    public float nbObstacles = 10;
    public float vitesseMeteorites = 2f;
    public float vitesseMines = 1f;

    //private GameObject[] objetsInstancies;

    void Start()
    {
        InvokeRepeating("instancierMeteorite1", 0f, 2f);
        //for (int i = 0, j = 0; i < nbObstacles; j++, i++)
        //{
        //    if (j == 0)
        //    {
        //        instancierObjet(meteorite1, i);
        //    }
        //    if (j == 1)
        //    {
        //        instancierObjet(meteorite2, i);
        //    }
        //    if (j == 2)
        //    {
        //        instancierObjet(meteorite3, i);
        //    }
        //    if (j == 3)
        //    {
        //        instancierObjet(mine, i);
        //        j = 0;
        //    }

        //}
    }

    private void instancierMeteorite1(GameObject objet)
    {
        //random la coordonnée (x,z)
        float x = UnityEngine.Random.Range(0f, 10f);
        float y = UnityEngine.Random.Range(-3f, 3f);

        //variable pour la position
        Vector3 pos = new Vector3(x, y, 0f);

        //instancier
        Instantiate(objet, pos, Quaternion.identity);
    }

    private void instancierObjet(GameObject objet, int i)
    {
        ////random la coordonnée (x,z)
        //float x = UnityEngine.Random.Range(0f, 10f);
        //float y = UnityEngine.Random.Range(-3f, 3f);

        ////variable pour la position
        //Vector3 pos = new Vector3(x, y, 0f);

        ////instancier
        //objetsInstancies[i] = Instantiate(objet, pos, Quaternion.identity);

        ///*instancier sa direction*/

        ////point cible
        //float yCible = UnityEngine.Random.Range(-2.3f, 2.3f);
        //Vector3 posCible = new Vector3(-2.3f, yCible, 0f);

        ////tourner vers la cible
        //objetsInstancies[i].transform.LookAt(posCible);

       
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //foreach(GameObject objet in objetsInstancies) 
        //{

        //    //direction
        //    Vector3 direction = objet.transform.forward;

        //    //déplacer vers la cible
        //    if( objet == mine)
        //    {
        //        objet.transform.Translate(direction * vitesseMines * Time.deltaTime);

        //    }
        //    else
        //    {
        //        objet.transform.Translate(direction * vitesseMeteorites * Time.deltaTime);
        //    }
        //}
    }
}
