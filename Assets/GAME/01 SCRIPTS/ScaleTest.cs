using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTest : MonoBehaviour
{
    [SerializeField] Transform newParent;
    [SerializeField] int level = 0;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (level < this.transform.parent.childCount - 1)
            {
                level++;
            }
            else
            {
                level = 0;

            }
            this.transform.SetSiblingIndex(level);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (level > 0)
            {
                --level;
            }
            else
            {
                level = this.transform.parent.childCount - 1;
            }
            this.transform.SetSiblingIndex(level);
        }

    }
}
