using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float jumpHeight = 1;

    [SerializeField] float speed = 1f;
    [SerializeField]
    Player_animation_controller Player_animation;
    [SerializeField] AnimationClip slideanimationclip;
    [SerializeField] AnimationClip diedanimationclip;
    [SerializeField] GameObject Maincamera;
    [SerializeField] GameObject Aimcamera;
    [SerializeField] GameObject exitMenu;
    [SerializeField] GameObject ScoreMenu;
    [SerializeField] AudioSource runnig;
    [SerializeField] AudioSource die;
    [SerializeField] AudioSource ExitSource;


    Vector3 movementVector;
    Transform m_Transform;
    bool Sliding = false;
    bool isDied = false;

    
    void Start()
    {
        m_Transform = transform;
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Player_Movement();
    }
                
    //Player actions function
        void Player_Movement()
        {

            if (isDied)
            {
                return;
            }

            float deltaTime = Time.deltaTime;
            movementVector.x = 0;
            ExitSource.Pause();
            runnig.Play();
        // Input Movement
        movementVector += m_Transform.right * Input.GetAxis("Horizontal");
               


                // Jump
                if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
                {
                    movementVector.y = Mathf.Sqrt(9.8F * jumpHeight * 2);
                    Player_animation.jump();
                }

                //Gravity
                movementVector.y -= 9.8F * deltaTime;
                if (movementVector.y < 0 && controller.isGrounded)
                {
                    movementVector.y = -5F;
                }

                // Rotation
                if (Input.GetKeyDown(KeyCode.A))
                    m_Transform.Rotate(new Vector3(0, -90f, 0));
                else if (Input.GetKeyDown(KeyCode.D))
                    m_Transform.Rotate(new Vector3(0, 90f, 0));

                // Forward Motion
                movementVector.z = 0;

                movementVector += m_Transform.forward * speed;
                controller.Move(movementVector * deltaTime);
                Player_animation.isrunning();
                GameManager.Instance.distancecovered();

                //Slide
                if (Input.GetKeyDown(KeyCode.S) && controller.isGrounded && !Sliding)
                {
                    StartCoroutine(Slide());
                }

                //Slide function
                IEnumerator Slide()
                {
                    //Shrink the collider
                    Sliding = true;
                    Vector3 OrginalControllerCenter = controller.center;
                    Vector3 NewControllerCenter = OrginalControllerCenter;
                    controller.height /= 2;
                    NewControllerCenter.y -= controller.height / 2;
                    controller.center = NewControllerCenter;


                    //Play the sliding animation
                    Player_animation.slide();
                    yield return new WaitForSeconds(slideanimationclip.length);

                    //Back orginal size after sliding 
                    controller.height *= 2;
                    controller.center = OrginalControllerCenter;
                    Sliding = false;

                }
        }

    //When player collide with pillers

        IEnumerator collied_piller()
        {
            runnig.Pause();
            Maincamera.SetActive(false);
            Aimcamera.SetActive(true);
            isDied = true;
            
           
            ScoreMenu.SetActive(false);
            Player_animation.Died();
            
            exitMenu.SetActive(true);
            ExitSource.Play();

             yield return new WaitForSeconds(diedanimationclip.length);
              
         }

    IEnumerator collied_down()
    {
        Maincamera.SetActive(false);
        Aimcamera.SetActive(true);
        isDied = true;
        ScoreMenu.SetActive(false);
        ExitSource.Play();
        Player_animation.isfalling();
           
        yield return new WaitForSeconds(diedanimationclip.length);
        exitMenu.SetActive(true);
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if(hit.gameObject.tag == "Pillers" && Aimcamera.activeInHierarchy)
            {
                runnig.Pause();
                die.Play();
                StartCoroutine(collied_piller());   
            }

            if (hit.gameObject.tag == "Sidepost" && Aimcamera.activeInHierarchy)
            {
                runnig.Pause();
                die.Play();
               StartCoroutine (collied_down());
            }
    }
}
