using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 direction = Vector3.zero;
    CharacterController controller;
    [SerializeField]
    float baseSpeed = 5;
    float speed;
    bool attacking = false;
    [SerializeField]
    Animator anim;

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

        transform.GetChild(0).LookAt(transform.position + direction);
        anim.SetBool("Moving", direction.magnitude != 0);
        if (Input.GetKeyDown(KeyCode.Space)) anim.SetTrigger("Attack");

        speed = attacking ? 0 : baseSpeed;

        controller.Move(direction.normalized * speed * Time.deltaTime);
    }
}
