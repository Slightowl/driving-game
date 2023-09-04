using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColour = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColour = new Color32(253, 0, 4, 255);
    [SerializeField] float destroyDelay = 1f;
    bool hasPackage;

    SpriteRenderer spriteRenderer;

    private void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Ouch");
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Package" && !hasPackage) 
        {
            Debug.Log("Package picked up!");
            hasPackage = true;
            spriteRenderer.color = hasPackageColour;
            Destroy(other.gameObject, destroyDelay);
            
        }
        if (other.gameObject.tag == "Customer" && hasPackage) 
        {
            Debug.Log("Package delivered");
            hasPackage = false;
            spriteRenderer.color = noPackageColour;
        }  
    }

}
