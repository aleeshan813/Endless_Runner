using UnityEngine;

public class Player_animation_controller : MonoBehaviour
{
    [SerializeField]
    Animator Player_animator;
    

    void Start()
    {
        Player_animator = GetComponent<Animator>();
    }

   public void isrunning()
    {
        Player_animator.SetBool("isRunning",true);
    }
    public void jump()
    {
        Player_animator.SetTrigger("Jump");
    }
    public void slide()
    {
        Player_animator.SetTrigger("Slide");
    }
    public void Died()
    {
        Player_animator.SetBool("Died", true);
    }
    public void isfalling()
    {  
         Player_animator.SetBool("isFalling", true);
    }
}
