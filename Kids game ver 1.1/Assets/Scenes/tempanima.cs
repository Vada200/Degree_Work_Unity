using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempanima : MonoBehaviour
{
    public Animator balloonAnimation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Animation()
    {
        balloonAnimation.Rebind();
        balloonAnimation.SetTrigger("baloonsUp");
    }
}
