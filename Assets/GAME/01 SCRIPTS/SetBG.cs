using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBG : MonoBehaviour
{
    Vector3 movement = new Vector3(0, 0, 0);
    [SerializeField] SpriteRenderer[] spritesBG;
    [SerializeField] Transform Player;
    [SerializeField] float _speed;
   
    void Update()
    {
        //movement.x = 0;
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    movement.x = -1;
        //}

        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    movement.x = 1;
        //}
        //for (int i = 0; i < spritesBG.Length; i++)
        //{
        //    spritesBG[i].transform.Translate((_speed + i) * Time.deltaTime * movement);
        //    if (Mathf.Abs(Player.transform.position.x - spritesBG[i].transform.position.x) >= spritesBG[i].sprite.texture.width / 16)
        //    {
        //        spritesBG[i].transform.position = Player.transform.position;

        //    }
            
        //}

    }
    private void OnDrawGizmosSelected()
    {
        spritesBG = GetComponentsInChildren<SpriteRenderer>();

        for (int i = 0; i < spritesBG.Length; i++)
        {
            spritesBG[i].sortingLayerName = "BG";
            spritesBG[i].sortingOrder = i;
        }
    }
}
