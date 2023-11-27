using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class instancievitesse : MonoBehaviour
{
    //variables du progamme
    public float vitesseMeteorites = 2f;
    public float vitesseMines = 1f;
    private int conteurIt�ration = 0;
    

    // Start is called before the first frame update
    void Start()
    {

        // tous le objets correpondant aux mines
        GameObject[] mines = GameObject.FindGameObjectsWithTag("mine");

        // Attribuez la v�locit� initiale aux objets trouv�s
        foreach (GameObject obj in mines)
        {
         

            Rigidbody rb = obj.GetComponent<Rigidbody>();
            
            /* donner une vitesse a l'objet */

            // V�rifier si l'objet a un composant Rigidbody
            if (rb != null)
            {
                // D�finir la v�locit� dans la direction souhait�e
                
                rb.velocity = getDirection() * vitesseMines;
            }
            else
            {
                Debug.LogWarning("L'objet " + obj.tag + " n'a pas de composant Rigidbody.");
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        // tous le objets correpondant aux mines
        GameObject[] mines = GameObject.FindGameObjectsWithTag("mine");

        // Attribuez la v�locit� initiale aux objets trouv�s
        foreach (GameObject obj in mines)
        {
            Rigidbody rb = obj.GetComponent<Rigidbody>();

            //v�rifie si il y a un rigidbody
            if (rb != null)
            {
                //rb.transform.position += velocity * Time.deltaTime;

                ////instancie la vitesse
                //if (conteurIt�ration == 0)
                //{
                //    //incr�mentation du conteur
                //    conteurIt�ration++;
                //    obj.transform.LookAt(getDirection());

                //    rb.velocity = obj.transform.forward * vitesseMines;
                //}
                //else
                //{
                //    rb.velocity = obj.transform.forward * vitesseMines;
                //}
            }
            else
            {
                Debug.LogWarning("L'objet " + obj.name + " n'a pas de composant Rigidbody.");
            }
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
}
