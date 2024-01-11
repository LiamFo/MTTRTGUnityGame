using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    float ScrollSpeed = 0.2f;
    private float offset;
    Renderer render;
    public Material _lavaMaterial;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>();
        offset = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //scroll texture offset downwards
        offset += Time.deltaTime * ScrollSpeed;
        render.material.mainTextureOffset = new Vector2(0, offset);

    }

}
