using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class jouerdeplacement : MonoBehaviour
{
    //variables
    public float vitesseJoueur = 2f;
    public float maxPosX;
    public float minPosX;
    public float maxPosY;
    public float minPosY;
    private Camera mainCamera;

    Transform deplacement;

    //varaible pour tirer
    public GameObject viseur;
    public GameObject projectil;
    public float vitesseProjectil;
    public float frequenceTir = 0.35f;
    private float frequenceActuelle;
    private bool peuTirer;
    //public AudioSource soundFire;

    // Start is called before the first frame update
    void Start()
    {
        //instanciation de fr�quences actuelle
        frequenceActuelle = frequenceTir;

        //instanciation de d�palcement
        deplacement = GetComponent<Transform>();

        //instanciation de la camera principale
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("La cam�ra principale n'a pas �t� trouv�e. Assurez-vous qu'il y a une cam�ra principale dans la sc�ne.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //entr�e directionnles du clavier
        float posX = Input.GetAxis("Horizontal");
        float posY = Input.GetAxis("Vertical");

        //direction r�sultante
        Vector3 nouvellePos = new Vector3 ( posX, posY, 0f);

        //effectuer le d.
        //�placement
        deplacement.Translate(nouvellePos * vitesseJoueur * Time.deltaTime);
        deplacement.position = new Vector3(Mathf.Clamp(deplacement.position.x, minPosX, maxPosX), Mathf.Clamp(deplacement.position.y, minPosY, maxPosY), deplacement.position.z);

        //appel de la fonction tire
        tire();
    }

    //fonction pour tirer
    private void tire()
    {
        frequenceTir += Time.deltaTime;

        //v�rifier si la fr�quence de tir es sup�rieur � celle autoris�
        if( frequenceTir > frequenceActuelle)
        {
            peuTirer = true;

        }

        //v�riier si il peut tirer
        if (peuTirer && Input.GetMouseButtonDown(0))
        {

            peuTirer = false;
            frequenceTir = 0f; /* resset de la f�quence de tir */

            //instancier et donner une vitesse � la position;
            GameObject munition = (GameObject)Instantiate(projectil, viseur.transform.position, Quaternion.identity); /* c�e le projectil */
            munition.GetComponent<Rigidbody>().AddForce((viseur.transform.position - transform.position) * vitesseProjectil);
            munition.GetComponent<AudioSource>().Play(); /* active le sond */

     
            
        }
    }
     

}
