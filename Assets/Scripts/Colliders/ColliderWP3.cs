using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderWP3 : MonoBehaviour
{
    [SerializeField] GameObject Player;
    private MovementControllerScript myMovementController;

    private int rotate;
    private float rotationSpeed = 2.0f;

    void Start()
    {
        rotate = 0;
        GameObject MovementController = GameObject.Find("MovementController");
        myMovementController = MovementController.GetComponent<MovementControllerScript>();
    }

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        //myMovementController.movementSpeed = 3.0f;
        rotate = 5;
        
    }

    private void Update()
    {
        if(rotate > 0)
        {
            Debug.Log("HEre");
            Player.transform.rotation = Quaternion.Lerp(Player.transform.rotation, Quaternion.AngleAxis(90, Vector3.up), rotationSpeed * Time.deltaTime);
            rotate--;
        }
        
    }
}
