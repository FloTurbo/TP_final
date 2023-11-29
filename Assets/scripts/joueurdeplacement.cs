using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    // Start is called before the first frame update
    void Start()
    {
        deplacement = GetComponent<Transform>();

        //instanciation de la camera principale
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("La caméra principale n'a pas été trouvée. Assurez-vous qu'il y a une caméra principale dans la scène.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //entrée directionnles du clavier
        float posX = Input.GetAxis("Horizontal");
        float posY = Input.GetAxis("Vertical");

        //direction résultante
        Vector3 nouvellePos = new Vector3 ( posX, posY, 0f);


        deplacement.Translate(nouvellePos * vitesseJoueur * Time.deltaTime);

        deplacement.position = new Vector3(Mathf.Clamp(deplacement.position.x, minPosX, maxPosX), Mathf.Clamp(deplacement.position.y, minPosY, maxPosY), deplacement.position.z);

        
    }

}
