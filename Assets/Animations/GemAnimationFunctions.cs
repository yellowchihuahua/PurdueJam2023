using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemAnimationFunctions : MonoBehaviour
{
    public void DestroyAfterAnimation()
    {
        GameObject.Destroy(gameObject);
    }
}
