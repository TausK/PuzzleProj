using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Animations;
namespace movement
{

    public class PlayerController : MonoBehaviour
    {
        public PlayerController controller;
        public GameObject rayCastPost;
        public PickUI ui;
        public Orbit camOrbit;
        public Animator anim;
        public Vector3 origin;

        public float speed = 0.5f;
        public float normSpeed = 0.5f;
        public float maxSpeed = 1f;
        public float gravityScale = 20;
        public float jumpForce = 10;
        public float delay = 0.2f;

        public float rayDist = 1f;
        // public LayerMask layerMask;
        //Default movement vector3 to 0
        private Vector3 moveDirection = Vector3.zero;
        public Transform cam;
        // private Rigidbody rb;
        private CharacterController charC;

        public bool grounded;


        // Use this for initialization
        void Start()
        {
            anim = GetComponent<Animator>();
            ui = GetComponent<PickUI>();
            origin = transform.position;
            charC = GetComponent<CharacterController>();
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Vector3 forward = Camera.main.transform.forward;
            Gizmos.DrawLine(rayCastPost.transform.position, rayCastPost.transform.position + forward * rayDist);
        }

        // Update is called once per frame
        void Update()
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            camOrbit.Look(mouseX, mouseY);
          
            PlayerMovement();

            PickObject();

        }


        void PlayerMovement()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            //Rotate the player in the direction of camera
            Vector3 euler = cam.transform.eulerAngles;
            transform.rotation = Quaternion.AngleAxis(euler.y, Vector3.up);

            ////if character is grounded then...
            if (charC.isGrounded)
            {
                Debug.Log(normSpeed);
                moveDirection = new Vector3(h, 0, v);
                //Move character within world space
                moveDirection = transform.TransformDirection(moveDirection);
                //Add speed to vector direction
                moveDirection *= speed;

                if (h >= 0.1 || h <= -0.1 || v >= 0.1 || v <= -0.1)
                {
                    anim.SetBool("isWalking", true);
                }
                else
                {
                    anim.SetBool("isWalking", false);
                }


                //if input key is pressed then....
                if (Input.GetButtonDown("Jump"))
                {
                    //Apply jump force in y axis upon character
                    moveDirection.y = jumpForce;
                    anim.SetTrigger("Jump");
                }

                anim.SetFloat("JumpBlend", moveDirection.y);

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    speed = maxSpeed;
                    anim.SetBool("isRunning", true);
                }
                else
                {
                    speed = normSpeed;
                    anim.SetBool("isRunning", false);
                   
                }

            }
            else
            {
            //    anim.SetBool("isWalking", false);
            //    anim.SetBool("isJumping", false);
            //    anim.SetBool("isRunning", false);
            }

            moveDirection.y -= gravityScale * Time.deltaTime;
            charC.Move(moveDirection * Time.deltaTime);

        }

        void PickObject()
        {
            //Ray rayCam = new Ray()
            Ray ray = new Ray(rayCastPost.transform.position, Camera.main.transform.forward);
            //Ray rayground = new Ray(transform.position, Vector3.down);
            RaycastHit hit;
            //   PickUp pick;
            if (Physics.Raycast(ray, out hit, rayDist))
            {
                PickUp pick = hit.collider.GetComponent<PickUp>();
                TriggerMetPlat metPlat = hit.collider.GetComponent<TriggerMetPlat>();
                //Debug.Log("Object Found");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (pick != null)
                    {
                        pick.picked = !pick.picked;
                    }

                    if (metPlat != null)
                    {
                        metPlat.actiSwitch = !metPlat.actiSwitch;
                    }
                }
                if (pick)
                {
                    ui.pickUI = !pick.picked;
                }
            }
            else
            {
                ui.pickUI = false;
            }


        }
    }
}

