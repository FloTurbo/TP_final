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
    private int nbObstacles = 4;
    public static int nbObstaclesRef;
    public float tempsFinInstanciations = 8f;


    //private GameObject[] objetsInstancies;
    private GameObject meteoriteTempo;
    public GameObject[] ensembleMines;
    private Rigidbody[] obstacles;

    void Start()
    {
        //si nb obstacles ref a été modifiée
        if(nbObstaclesRef != 0)
        {
            nbObstacles = nbObstaclesRef;
        }

        //appel des fonctions instanciant les obstacles
        InvokeRepeating("instancierMeteorite1", 0f, tempsEntreVagues);
        InvokeRepeating("instancierMeteorite2", 0f, tempsEntreVagues);
        InvokeRepeating("instancierMeteorite3", 0f, tempsEntreVagues);
        InvokeRepeating("instancierMines", 0f, tempsEntreVagues);

        //arrête tous les invokes apres le temps désigné
        //Invoke("stop", tempsFinInstanciations);
    }

    // Update is called once per frame
    void Update()
    {
        //modifie si il y a un changement
        if (nbObstaclesRef != nbObstacles)
        {
            nbObstacles = nbObstaclesRef;
        }
    }

    private void instancierMeteorite1()
    {
        for (int i = 0; i < (nbObstacles/4); i++)
        {
            //random la coordonnée (x,y)
            float x = UnityEngine.Random.Range(0f, 10f);
            float y = UnityEngine.Random.Range(-3f, 3f);

            //variable pour la position
            Vector3 pos = new Vector3(x, y, 0f);

            //instancier
            meteoriteTempo = Instantiate(meteorite1, pos, Quaternion.identity);

     
        }
    }

    private void instancierMeteorite2()
    {
        for (int i = 0; i < (nbObstacles / 4); i++)
        {
            //random la coordonnée (x,y)
            float x = UnityEngine.Random.Range(0f, 10f);
            float y = UnityEngine.Random.Range(-3f, 3f);

            //variable pour la position
            Vector3 pos = new Vector3(x, y, 0f);

            //instancier
            meteoriteTempo = Instantiate(meteorite2, pos, Quaternion.identity);

         
        }
    }

    private void instancierMeteorite3()
    {

        for (int i = 0; i < (nbObstacles / 4); i++)
        {
            

            //random la coordonnée (x,y)
            float x = UnityEngine.Random.Range(0f, 10f);
            float y = UnityEngine.Random.Range(-3f, 3f);

            //variable pour la position
            Vector3 pos = new Vector3(x, y, 0f);

            //instancier
            Instantiate(meteorite3, pos, Quaternion.identity);

        }
    }

    private void instancierMines()
    {

        for (int i = 0; i < (nbObstacles / 4); i++)
        {
            //random la coordonnée (x,y)
            float x = UnityEngine.Random.Range(0f, 10f);
            float y = UnityEngine.Random.Range(-3f, 3f);

            //variable pour la position
            Vector3 pos = new Vector3(x, y, 0f);

            //instancier
            Instantiate(mine, pos, Quaternion.identity);
           
           
        }
    }
  
    //private void stop()
    //{
    //    //met fin aux prossesues invoke
    //    CancelInvoke();
    //}
}
