using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    

    public Vector3 startPos;
    public Vector3 moveToPos;
    public BlockScript block;
    public int speed = 6;
    public int tileSize = 5;
    public Vector3 currentPos;
    Vector3 nextStep;
    public Vector2 pointOfInterest;
    public GameObject occupying;
    Vector3 pos;
    float t = 0;
    bool enoughMovement = false;
    int totalMove = 0;

    public bool moving = false;
    float timer = 0;

    Vector3[] steps;
    bool calculatedMovement = false;
    int step = 0;
    bool finished = true;

    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.localScale.y, transform.position.z);
        currentPos = transform.position;
        moveToPos = transform.position;
        pos = transform.position;
    }

    void Update()
    {
        t = Time.deltaTime;
        currentPos = transform.position;

        if(finished)
        {
            if (moving)
                CheckMovement();
            if (enoughMovement)
            {
                ProjectMovement(moveToPos);
            }
        }

        if(calculatedMovement)
        {
            Move(steps, totalMove);
        }

        transform.position = pos;
    }

    void ProjectMovement(Vector3 moveToPos)
    {
        int xSteps = (int)pos.x - (int)moveToPos.x;
        startPos = transform.position;

        Vector3[] path = new Vector3[totalMove];

        for (int i = 0; i < path.Length; i++)
        {
            if(startPos.x < moveToPos.x)
            {
                if (i == 0)
                {
                    path[i] = startPos + new Vector3(1, 0, 0);
                }
                else if(path[i - 1].x < moveToPos.x)
                {
                    path[i] = path[i - 1] + new Vector3(1, 0, 0);
                }
            }
            else if (startPos.x > moveToPos.x)
            {
                if (i == 0)
                {
                    path[i] = startPos - new Vector3(1, 0, 0);
                }
                else if (path[i - 1].x > moveToPos.x)
                {
                    path[i] = path[i - 1] - new Vector3(1, 0, 0);
                }
            }

            if (path[i].z < moveToPos.z)
            {
                if (i == 0)
                {
                    path[i] = startPos + new Vector3(0, 0, 1);
                }
                else
                {
                    path[i] = path[i - 1] + new Vector3(0, 0, 1);
                }
            }
            else if (path[i].z > moveToPos.z)
            {
                if (i == 0)
                {
                    path[i] = startPos - new Vector3(0, 0, 1);
                }
                else
                {
                    path[i] = path[i - 1] - new Vector3(0, 0, 1);
                }
            }

            if (i == path.Length - 1)
            {
                enoughMovement = false;
                moving = false;
            }
        }

        steps = path;
        calculatedMovement = true;
        finished = false;
    }

    private void Move(Vector3[] path, int steps)
    {
        timer += Time.deltaTime;

        if (step < steps)
        {
            if (timer < 0.7f)
            {
                pos = Vector3.MoveTowards(transform.position, path[step], 5 * Time.deltaTime);
            }
            else
            {
                ++step;
                timer = 0;
            }
        }
        else
        {
            finished = true;
            enoughMovement = false;
            calculatedMovement = false;
            step = 0;
        }
    }

    bool CheckOccupation(int i, int j)
    {
        string find = "Block(" + i + "," + j + ")";
        GameObject block = GameObject.Find(find);
        if(block != null)
        {
            BlockScript blockScript = block.GetComponent<BlockScript>();

            if (blockScript.occupied)
                return false;
            else
                return true;
        }
        else
        {
            print("nani");
            return false;
        }

    }

    void CheckMovement()
    {
        float xMove = pos.x - moveToPos.x;
        float zMove = pos.z - moveToPos.z;

        totalMove = (int)(Mathf.Abs(xMove) + Mathf.Abs(zMove));

        if (totalMove <= speed)
        {
            print("Enough");
            enoughMovement = true;
        }
        else
        {
            print("Not enough");
            enoughMovement = false;
        }
    }
}
