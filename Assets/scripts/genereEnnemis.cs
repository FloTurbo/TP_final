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
        //génère les ennemis
        InvokeRepeating("instacierEnnemi", 0f, tempsEntreVagues);

        //arrête tous les invokes apres le temps désigné
        Invoke("stop", 12);
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void instacierEnnemi()
    {

        //boucle qui instancie les ennemis en fonction du nombre par vagues
        for (int i = 0; i < nbEnnemisVague; i++)
        {
            //random une position y
            float y = UnityEngine.Random.Range(-3f, 3f);

            //vairable pour la position de l'ennemi
            Vector3 pos = new Vector3(6, (Mathf.Clamp(y, minPosY, maxPosY)), 0);

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
