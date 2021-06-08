using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    Animator anim;
    int aCaminharHash;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        aCaminharHash = Animator.StringToHash("aCaminhar");
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = anim.GetBool(aCaminharHash);
        bool wPressed = Input.GetKey("w");
        bool aPressed = Input.GetKey("a");
        bool sPressed = Input.GetKey("s");
        bool dPressed = Input.GetKey("d");
        bool leftPressed = Input.GetKey("left");
        bool rightPressed = Input.GetKey("right");
        bool downPressed = Input.GetKey("down");
        bool upPressed = Input.GetKey("up");

        if (!isWalking && (wPressed || aPressed || sPressed || dPressed || leftPressed || rightPressed || downPressed || upPressed))
        {
            anim.SetBool(aCaminharHash, true);
        }

        if (isWalking && (!wPressed && !aPressed && !sPressed && !dPressed && !leftPressed && !rightPressed && !downPressed && !upPressed))
        {
            anim.SetBool(aCaminharHash, false);
        }
    }
}