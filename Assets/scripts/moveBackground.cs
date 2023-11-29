using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public float vitesseFond;
    private Renderer bgRenderer;

    // Start is called before the first frame update
    void Start()
    {
        //instanciation de la variable renderer
        bgRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //fait déplcer le fond
        bgRenderer.material.mainTextureOffset += new Vector2(-vitesseFond * Time.deltaTime, 0);
    }
}
