using UnityEngine;

/// <summary>
/// VFXgit st
/// </summary>
public class VFX : MonoBehaviour
{
    public Animator anim;
    AnimatorStateInfo state => gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (state.IsName("destroy"))
        {
            Destroy(gameObject);
        }
    }
}
