using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHandle : MonoBehaviour
{
    
      private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                Ipopable PopObject = hit.collider.GetComponent<Ipopable>();
                if (PopObject != null)
                {
                    PopObject.pop();
                }
            }
        }
    }

}
