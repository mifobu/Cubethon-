using UnityEngine;
 
 public class grid : MonoBehaviour
 {
     //It is much easier to use a direction vector
     //than four bool variables and four conditions.
     Vector3 movingDirection = Vector3.forward;
 
     //We use end position to snap to grid.
     Vector3 targetPosition;
 
     //Grid cell size
     public float lengthCellGrid = 1;
     public float speed = 1;
 
     void Start()
     {
         targetPosition = transform.position;
     }
 
     void Update()
     {
         GridMove();
     }
 
     void GridMove()
     {
         if (Input.GetKeyDown(KeyCode.A))
         {
             movingDirection = Vector3.left * lengthCellGrid;
         }
         if (Input.GetKeyDown(KeyCode.D))
         {
             movingDirection = Vector3.right * lengthCellGrid;
         }
 
         // Shift targetPosition if we got to it
         bool isGoing = Input.GetButton("Horizontal");
         if (targetPosition == transform.position && isGoing)
         {
             Ray ray = new Ray(transform.position + Vector3.up + movingDirection, Vector3.down);
             RaycastHit hit;
 
             if (Physics.Raycast(ray, out hit, 1))
             {
                 if (hit.collider.CompareTag("Floor"))
                 {
                     targetPosition += movingDirection;
                 }
             }
         }
 
         // Moving to targetPosition
         transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
     }
 }