using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class impactDestroy : MonoBehaviour
{
    [SerializeField] private float destroyTime = 1f;
    void Start()
    {
        DestroyImpact();
    }

    // Update is called once per frame
    private void DestroyImpact()
    {
        Destroy(gameObject, destroyTime);
    }
    
        
    
}
