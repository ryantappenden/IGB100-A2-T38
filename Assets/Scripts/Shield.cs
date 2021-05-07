using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public bool isBlocking;

    Animation shieldAnimation;

    public GameObject WoodenShield;
    private void Start()
    {
        shieldAnimation = GetComponent<Animation>();
    }

    private void Update()
    {
        //Raises the shield when the player right-clicks
        if(Input.GetMouseButtonDown(1) && !isBlocking)
        {
            isBlocking = true;
            shieldAnimation.Play("Block");
        }
        //Lowers the shield when the player releases right-click
        else if (!Input.GetMouseButton(1) && isBlocking)
        {
            isBlocking = false;
            shieldAnimation.Play("BlockEnd");
        }
    }


    

}