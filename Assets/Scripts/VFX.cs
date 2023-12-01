using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;

    AnimatorStateInfo state => gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (state.IsName("destroy"))
        {
            Destroy(gameObject);
        }
    }
}
