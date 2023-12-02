using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 direction = Vector3.zero;
    CharacterController controller;
    [SerializeField]
    float speed = 5;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) direction.z += 1;
        if (Input.GetKey(KeyCode.S)) direction.z -= 1;
        if (Input.GetKey(KeyCode.D)) direction.x += 1;
        if (Input.GetKey(KeyCode.A)) direction.x -= 1;

        controller.Move(direction.normalized * speed * Time.deltaTime);
    }
}
