using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintedBrush : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;

    [Header(" BrushColorId0 = Green || BrushColorId1 = Red || BrushColorId2 = Turquoise || BrushColorId3 = Blue")]
    [SerializeField] private int brushColorID;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            anim.SetBool("brushAnim", true);

            ColorManager.Instance.SetColors(brushColorID);
        }
    }

}
