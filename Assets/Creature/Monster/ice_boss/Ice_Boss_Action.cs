using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class Ice_Boss_Action : MonoBehaviour
{
    static int MoveState1 = Animator.StringToHash("Base Layer.moveStart");
    static int MoveState2 = Animator.StringToHash("Base Layer.moveGoing");
    static int MoveState3 = Animator.StringToHash("Base Layer.moveEnd");
    static int TurnLeftState2 = Animator.StringToHash("Base Layer.turnLeft2");
    private Animator anim;
    private AnimatorStateInfo currentBaseState;
    Transform look;
    private Vector3 velocity;
    float move1time = 0f;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        look = transform.Find("look");
        velocity = new Vector3(0.0f, 0.0f, -1.0f);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        currentBaseState = anim.GetCurrentAnimatorStateInfo(0);
        velocity = look.position - transform.position;
        if (currentBaseState.nameHash == MoveState1)
        {
            move1time+= Time.fixedDeltaTime;
            if(move1time>0.05f)transform.localPosition += velocity * 3f * Time.fixedDeltaTime;

        }
        else
        {
            move1time = 0;
        }
        if (currentBaseState.nameHash == MoveState2 || currentBaseState.nameHash == MoveState3)
        {
            transform.localPosition += velocity * 3.6f * Time.fixedDeltaTime;
            
        }
        if (currentBaseState.nameHash == TurnLeftState2)
        {
            transform.Rotate(Vector3.down * 36f * Time.deltaTime);

        }
    }
}
