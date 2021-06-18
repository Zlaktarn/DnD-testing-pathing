using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHover : MonoBehaviour
{
    MeshRenderer mesh;
    CharacterScript character;

    public bool hovering = false;
    public bool occupied = false;

    void Start()
    {
        character = GameObject.Find("Player").GetComponent<CharacterScript>();
        mesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!occupied)
        {
            if (hovering)
                mesh.enabled = true;
            else
                mesh.enabled = false;
        }
        else
            mesh.enabled = false;

    }

    private void OnMouseOver()
    {
        hovering = true;
        character.pointOfInterest = new Vector3(transform.position.x, character.transform.position.y,transform.position.z);

    }

    private void OnMouseExit()
    {
        hovering = false;

    }
}