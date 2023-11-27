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
    private GameObject meteoriteTempo;
    public GameObject[] ensembleMines;
    private Rigidbody[] obstacles;

    void Start()
    {
        //appel des fonctions instanciant les obstacles
        InvokeRepeating("instancierMeteorite1", 0f, tempsEntreVagues);
        InvokeRepeating("instancierMeteorite2", 0f, tempsEntreVagues);
        InvokeRepeating("instancierMeteorite3", 0f, tempsEntreVagues);
        InvokeRepeating("instancierMines", 0f, tempsEntreVagues);

    }

    private void instancierMeteorite1()
    {
        for (int i = 0; i < (nbObstacles/4); i++)
        {
            //random la coordonnée (x,z)
            float x = UnityEngine.Random.Range(0f, 10f);
            float y = UnityEngine.Random.Range(-3f, 3f);

            //variable pour la position
            Vector3 pos = new Vector3(x, y, 0f);

            //instancier
            meteoriteTempo = Instantiate(meteorite1, pos, Quaternion.identity);

            ///* donner une vitesse èa l'objet */

            //Rigidbody rb = meteoriteTempo.GetComponent<Rigidbody>();

            //// Vérifier si l'objet a un composant Rigidbody
            //if (rb != null)
            //{
            //    // Définir la vélocité dans la direction souhaitée
            //    rb.velocity = getDirection() * vitesseMeteorites;
            //}
            //else
            //{
            //    Debug.LogWarning("L'objet " + meteoriteTempo.tag + " n'a pas de composant Rigidbody.");
            //}
        }
    }

    private void instancierMeteorite2()
    {
        for (int i = 0; i < (nbObstacles / 4); i++)
        {
            //random la coordonnée (x,z)
            float x = UnityEngine.Random.Range(0f, 10f);
            float y = UnityEngine.Random.Range(-3f, 3f);

            //variable pour la position
            Vector3 pos = new Vector3(x, y, 0f);

            //instancier
            meteoriteTempo = Instantiate(meteorite2, pos, Quaternion.identity);

            ///* donner une vitesse èa l'objet */

            //Rigidbody rb = meteoriteTempo.GetComponent<Rigidbody>();

            //// Vérifier si l'objet a un composant Rigidbody
            //if (rb != null)
            //{
            //    // Définir la vélocité dans la direction souhaitée
            //    rb.velocity = getDirection() * vitesseMeteorites;
            //}
            //else
            //{
            //    Debug.LogWarning("L'objet " + meteoriteTempo.tag + " n'a pas de composant Rigidbody.");
            //}
        }
    }

    private void instancierMeteorite3()
    {

        for (int i = 0; i < (nbObstacles / 4); i++)
        {
            

            //random la coordonnée (x,z)
            float x = UnityEngine.Random.Range(0f, 10f);
            float y = UnityEngine.Random.Range(-3f, 3f);

            //variable pour la position
            Vector3 pos = new Vector3(x, y, 0f);

            //instancier
            Instantiate(meteorite3, pos, Quaternion.identity);

            ///* donner une vitesse èa l'objet */

            //Rigidbody rb = meteorite3.GetComponent<Rigidbody>();

            //// Vérifier si l'objet a un composant Rigidbody
            //if (rb != null)
            //{
            //    // Définir la vélocité dans la direction souhaitée
            //    rb.velocity = getDirection() * vitesseMeteorites;
            //}
            //else
            //{
            //    Debug.LogWarning("L'objet " + meteorite3.tag + " n'a pas de composant Rigidbody.");
            //}
        }
    }

    private void instancierMines()
    {

        for (int i = 0; i < (nbObstacles / 4); i++)
        {
            //random la coordonnée (x,z)
            float x = UnityEngine.Random.Range(0f, 10f);
            float y = UnityEngine.Random.Range(-3f, 3f);

            //variable pour la position
            Vector3 pos = new Vector3(x, y, 0f);

            //instancier
            Instantiate(mine, pos, Quaternion.identity);
           

            ///* donner une vitesse a l'objet */

            //Rigidbody rb = mine.GetComponent<Rigidbody>();

            //// Vérifier si l'objet a un composant Rigidbody
            //if (rb != null)
            //{
            //    // Définir la vélocité dans la direction souhaitée
            //    rb.velocity = getDirection() * vitesseMines;
            //}
            //else
            //{
            //    Debug.LogWarning("L'objet " + mine.tag + " n'a pas de composant Rigidbody.");
            //}
        }
    }

    private Vector3 getDirection()
    {
        /*instancier une direction*/

        //point cible
        float yCible = UnityEngine.Random.Range(-2.3f, 2.3f);
        Vector3 posCible = new Vector3(-2.3f, yCible, 0f);

       return posCible;
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
