using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    Vector2 movementVector;

    [SerializeField] private float speed = 20f;

    private float MovementX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = new Vector3(MovementX, 0, 0);
        transform.Rotate(rotation * (speed * Time.deltaTime));
    }

    void OnMove(InputValue movement)
    {
        
        movementVector = movement.Get<Vector2>();
        MovementX = Mathf.RoundToInt(movementVector.x);
    }
}
