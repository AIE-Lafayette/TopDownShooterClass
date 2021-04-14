using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{
    [Tooltip("How fast the p[layer will move.")]
    [SerializeField]
    private float _moveSpeed;
    [Tooltip("The current active camera. Used to get mouse position for rotation.")]
    [SerializeField]
    private Camera _camera;
    private Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        //Store reference to the attached rigidbody
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //The direction the player is moving in is set to the input values for the horizontal and vertical axis
        Vector3 moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //The move direction is scaled by the movement speed to get velocity
        Vector3 velocity = moveDir * _moveSpeed * Time.deltaTime;

        //Call to make the rigidbody smoothly move to the desired position
        _rigidbody.MovePosition(transform.position + velocity);

        //Create a ray that starts at a screen point
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        //Checks to see if the ray hits any object in the world
        if (Physics.Raycast(ray, out hit))
        {
            //Find the direction the player should look towards
            Vector3 lookDir = new Vector3(hit.point.x, transform.position.y, hit.point.z) - transform.position;
            //Create a rotation from the player's forward to the look direction
            Quaternion rotation = Quaternion.LookRotation(lookDir);
            //Set the rotation to be the new rotation found
            _rigidbody.MoveRotation(rotation);
        }
    }
}
