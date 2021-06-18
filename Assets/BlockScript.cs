using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    public Vector2 blockPos;
    public CharacterScript character;

    public bool hovering = false;
    public bool occupied = false;

    public GameObject hitbox;
    BlockHover blockHover;
    MeshRenderer mesh;

    void Start()
    {
        blockHover = hitbox.GetComponent<BlockHover>();
        mesh = hitbox.GetComponent<MeshRenderer>();
    }

    void Update()
    {
        hovering = blockHover.hovering;
        blockHover.occupied = occupied;

        if (hovering && !occupied)
        {
            character = GameObject.Find("Player").GetComponent<CharacterScript>();

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                character.moveToPos = new Vector3(transform.position.x, character.transform.position.y, transform.position.z);
                character.moving = true;

                if (character.block != null)
                {
                    character.block.occupied = false;
                }

                character.block = this;
            }
        }
        else
        {
            character = null;
        }
    }
}
