using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    Vector3 mousePos;
    List<Vector3> moves = new List<Vector3>();
     [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            moves.Add(mousePos);
        }
        if(moves.Count > 0)
        {
            
            Vector3 currentTarget = moves[0];   
                if (Vector3.Distance(transform.position, currentTarget) > 0.1f) // Kiểm tra nếu chưa đến đích
                {
                  this.transform.position = Vector2.MoveTowards(transform.position, currentTarget, 5 * Time.deltaTime);
                }else
                {
                    moves.Remove(currentTarget);
                }
           
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        for (int i = 0; i < moves.Count - 1; i++)
        {
            Gizmos.DrawLine(moves[i], moves[i + 1]);
        }
    }
}
