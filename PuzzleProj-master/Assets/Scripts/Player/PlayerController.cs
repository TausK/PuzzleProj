using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace movement
{

    public class PlayerController : MonoBehaviour
    {
        public PlayerController controller;
        public GameObject rayCastPost;
        private PickUI ui;
        public Orbit camOrbit;

        public Vector3 origin;

        public float speed = 0.5f;
        public float normSpeed = 0.5f;
        public float maxSpeed = 1f;
        public float gravityScale = 20;
        public float jumpForce = 10;
        private bool isRunning = false;
        public float delay = 0.2f;

        public float rayDist = 1f;
        // public LayerMask layerMask;
        //Default movement vector3 to 0
        private Vector3 moveDirection = Vector3.zero;
        public Transform cam;
        // private Rigidbody rb;
        private CharacterController charC;



        // Use this for initialization
        void Start()
        {
            ui = GetComponent<PickUI>();
            origin = transform.position;
            charC = this.GetComponent<CharacterController>();
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

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.visible = true;
            }
            PlayerMovement();

            PickObject();

        }


        //IEnumerator JumpDelay()
        //{
        //    yield return new WaitForSeconds(delay);
        //}

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
                //Debug.Log(charC.isGrounded);
                moveDirection = new Vector3(h, 0, v);
                //Move character within world space
                moveDirection = transform.TransformDirection(moveDirection);
                //Add speed to vector direction
                moveDirection *= speed;

                //if input key is pressed then....
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    //Apply jump force in y axis upon character
                    moveDirection.y = jumpForce;
                    // StartCoroutine("JumpDelay");
                    // Debug.Log(delay * Time.deltaTime);
                }

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    speed = maxSpeed;
                }
                else
                {
                    speed = normSpeed;
                }
            }
            //else
            //{
            //    moveDirection.y -= gravityScale * Time.deltaTime;
            //}
            moveDirection.y -= gravityScale * Time.deltaTime;
            charC.Move(moveDirection * Time.deltaTime);
            // Debug.Log(charC.isGrounded);
        }

        void PickObject()
        {
            //Ray rayCam = new Ray()
            Ray ray = new Ray(rayCastPost.transform.position, Camera.main.transform.forward);
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

                ui.pickUI = !pick.picked;
            }
            else
            {
                ui.pickUI = false;
            }
        }
    }
}

