using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Creature : MonoBehaviour
{
    public string Name;
    public int State;// idle = 0, attack = 1, die = 2
    public int HP, ATK, DEF, SPD, MAT, MDF, MP;
    static int atkState = Animator.StringToHash("Base Layer.Attack");
    static int dmState = Animator.StringToHash("Base Layer.Damage");
    static int deadState = Animator.StringToHash("Base Layer.Dead");
    static int skillState = Animator.StringToHash("Base Layer.Skill");
    public Animator anim;
    public int damage;
    public Creature enemy;
    public SystemController SC;
    public bool moveEnd;
    public bool reactionEnd;
    public int currentState,newState;
    public MessageController MC;
    public string message;
    public string extraMessage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void FixedUpdate()
    {
        newState = anim.GetCurrentAnimatorStateInfo(0).nameHash;
        if (newState != currentState) {
            if (newState == atkState)
            {
                MC.newMessage(message);
                anim.SetBool("atk", false);
            }
            else if (newState == dmState)
            {
                MC.newMessage(message);
                if (extraMessage != "")
                {
                    MC.newMessage(extraMessage);
                    extraMessage = "";
                }
                anim.SetBool("damage", false);
            }
            else if (newState == skillState) {
                MC.newMessage(message);
                anim.SetBool("skill", false);
            }
            else if (newState == deadState)
            {
                MC.newMessage(Name+"倒下了");
            }
            if (HP <= 0) anim.SetBool("dead", true);
            if (SC.GetPart() != 2)
            {
                if ((newState == deadState) && gameObject.tag == "Player")
                {
                    SC.gameover();
                }
                else if (currentState == dmState) gameObject.GetComponent<Hero>().Resume();
                 
            }
            else if ((newState == deadState)&& gameObject.tag == "Player")
            {
                SC.gameover();
            }
            else if ((newState == deadState) && gameObject.tag == "Boss")
            {
                SC.gameclear();
            }
            else if ((currentState == atkState || currentState == skillState))
            {
                //anim.SetBool("atk", false);
                GiveDamage();
            }
            else if (currentState == dmState)
            {
                if (gameObject.tag == "Player") SC.monsTurnEnd = true;
                else SC.heroTurnEnd = true;
            }
            else if ((currentState == deadState) && gameObject.tag != "Boss")
            {
                if (gameObject.tag == "Player") SC.gameover();
                else
                {
                    SC.battleend(true);
                }
            }
            

        }
        currentState = newState;
    }
    
    public void Attack()
    {
        message = Name+"發動攻擊";
        anim.SetBool("atk", true);
        //State = 1;
        enemy.damage = ATK;
        //Invoke("GiveDamage", 1f);
    }
    public virtual void turn()
    {
        Attack();
    }

    void GiveDamage()
    {
        enemy.GetDamage();
    }

    bool done()
    {
        if (State == 1) return true;
        else return false;
    }
    
    public void GetDamage()
    {
        if ((damage-DEF) > 0)
        {
            if((damage-DEF) > 0)message = ("造成" + (damage - DEF) + "點傷害");
            anim.SetBool("damage", true);
        }
        else
        {
            MC.newMessage("但是沒有效果");
            if (gameObject.tag == "Player") SC.monsTurnEnd = true;
            else SC.heroTurnEnd = true;
        }
        HP -= (damage - DEF);
        if (HP <= 0)
        {
            
            anim.SetBool("dead", true);
        }
        /*if(HP <= 0)
        {
            //Invoke("end", 2f);
            
            end();
        }
        else
        {
            
            //Invoke("Attack", 1f);
        }*/
        //print(Damage);
    }
    public virtual void end()
    {
        SC.battleend(true);
    }

    public void GetMagicDamage()
    {
        anim.SetBool("damage", true);
        HP -= damage / MDF;
    }
}
