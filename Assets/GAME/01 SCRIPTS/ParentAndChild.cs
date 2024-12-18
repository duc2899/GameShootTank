using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentAndChild : MonoBehaviour
{
    SpriteRenderer[] spriteRenderers;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
           for(int i = 0; i < spriteRenderers.Length; i++)
            {
                spriteRenderers[i].transform.parent = null;
                spriteRenderers[i].transform.position = new Vector3(i * 5, 1, 0);
                spriteRenderers[i].transform.parent = this.transform;
            }
        }
    }
}
