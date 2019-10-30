using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class ActionController : MonoBehaviour
{
    static int MoveState = Animator.StringToHash("Base Layer.moving");
    static int DownState = Animator.StringToHash("Base Layer.down");
    static int DeadState = Animator.StringToHash("Base Layer.dead");
    static int BreathState2 = Animator.StringToHash("Base Layer.breath_atk");
    static int TukamiState1 = Animator.StringToHash("Base Layer.tukami");
    static int TukamiState2 = Animator.StringToHash("Base Layer.tukami_atk");
    static int TukamiState3 = Animator.StringToHash("Base Layer.tukami_nageru");
    static int IdleState = Animator.StringToHash("Base Layer.idle");
    static int TurnLeftState2 = Animator.StringToHash("Base Layer.turn_left_turning");
    static int TurnRightState2 = Animator.StringToHash("Base Layer.turn_right_turning");
    static int TurnLeftState4 = Animator.StringToHash("Base Layer.turn_left_end");
    static int TurnRightState4 = Animator.StringToHash("Base Layer.turn_right_end");
    static int WalkState0 = Animator.StringToHash("Base Layer.walk_start");
    static int WalkState1 = Animator.StringToHash("Base Layer.walking1");
    static int WalkState2 = Animator.StringToHash("Base Layer.walking2");
    static int BackState0 = Animator.StringToHash("Base Layer.back_ready");
    static int BackState1 = Animator.StringToHash("Base Layer.back_atk");
    static int BackState2 = Animator.StringToHash("Base Layer.back_end");
    static int WhipState = Animator.StringToHash("Base Layer.whip_left");
    static int RestState = Animator.StringToHash("Base Layer.rest");
    static int RightFindState = Animator.StringToHash("Base Layer.right_find");
    static int RightFindState2 = Animator.StringToHash("Base Layer.right_find_atk");
    static int LeftFindState = Animator.StringToHash("Base Layer.left_find");
    static int LeftFindState2 = Animator.StringToHash("Base Layer.left_find_atk");
    static int SpeedState2 = Animator.StringToHash("Base Layer.speed_turning");
    static int SpeedState3 = Animator.StringToHash("Base Layer.speed_turning2");
    static int RollLeftState2 = Animator.StringToHash("Base Layer.roll_left_atk1");
    static int RollLeftState3 = Animator.StringToHash("Base Layer.roll_left_atk2");
    static int RollLeftState4 = Animator.StringToHash("Base Layer.roll_left_atk3");
    static int RollLeftState5 = Animator.StringToHash("Base Layer.roll_left_atk4");
    static int RollLeftState6 = Animator.StringToHash("Base Layer.roll_left_atk5");
    static int left_tuda = 2;
    static int right_tuda = 3;
    static int karata = 1;
    private Animator anim;
    private AnimatorStateInfo currentBaseState;
    Transform look;
    public ParticleSystem breath;
    private Vector3 velocity;
    private Vector3 vsplayer;
    float time;
    float posy;
    float rotx;
    Quaternion rot;
    int preState;
    int HP;
    int[] Special;
    GameObject prefab;
    public GameObject drop;
    public GameObject player;
    bool hasDrop;
    Transform drop_point;
    bool atari;
    int hate, tired;
    bool hashit;
    bool tukanda;
    public GameObject eventsystem;
    public GameObject tukami_point;
    int turn_speed;
    float ini_y;
    bool rest, kaku;
    int[] DEF;
    int[] fireDEF;
    int[] iceDEF;
    int downTime = 0;
    // Use this for initialization
    void Start()
    {
        atari = false;
        kaku = false;
        anim = GetComponent<Animator>();
        look = transform.Find("look");
        velocity = new Vector3(0.0f, 0.0f, 1.0f);
        vsplayer = new Vector3(1.0f, 0.0f, 0.0f);
        posy = transform.position.y;
        rotx = transform.rotation.x;
        rot = transform.rotation;
        HP = 800;
        time = 0f;
        preState = IdleState;
        Special = new int[10];
        DEF = new int[4];
        fireDEF = new int[4];
        iceDEF = new int[4];
        DEF[1] = 20;
        DEF[2] = 10;
        DEF[3] = 10;
        fireDEF[1] = 3;
        fireDEF[2] = 5;
        fireDEF[3] = 5;
        iceDEF[1] = 10;
        iceDEF[2] = 15;
        iceDEF[3] = 15;
        hasDrop = false;
        drop_point = transform.Find("drop_point");
        hate = 0;
        //breath.enableEmission = false;
        hashit = false;
        tukanda = false;
        turn_speed = 0;
        ini_y = transform.position.y;
        rest = false;
        tired = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (HP <= 0)
        {

            anim.SetBool("dead", true);
        }
        /*else if (HP < 300 && downTime == 1)
        {

            anim.SetBool("down", true);
        }
        else if (HP < 700 && downTime ==0)
        {

            anim.SetBool("down", true);
        }*/
        currentBaseState = anim.GetCurrentAnimatorStateInfo(0);
        //velocity = look.position - transform.position;
        //vsplayer = player.transform.position - transform.position;
        float cos = Vector3.Dot(velocity, vsplayer) / (vsplayer.magnitude * velocity.magnitude);

        float direction = velocity.z * vsplayer.x - velocity.x * vsplayer.z;
        if (currentBaseState.nameHash != preState)
        {
            time = 0;
            hasDrop = false;
            anim.SetBool("find", false);
            anim.SetBool("owaru", false);
            anim.SetBool("down", false);
            anim.SetBool("atari", false);
            anim.SetBool("tukami", false);
            anim.SetBool("whip_left", false);
            anim.SetBool("breath", false);
            anim.SetBool("back", false);
            anim.SetBool("speed_turn", false);
            anim.SetBool("roll_left", false);
            anim.SetBool("rest", false);
            anim.SetBool("left_find", false);
            anim.SetBool("right_find", false);
            //breath.enableEmission = false;
            hashit = false;
            rest = false;
            kaku = false;
        }


        if (cos > 0.9 && hate > 20)
        {
            anim.SetBool("find", true);
        }
        if (hate == 0)
        {
            if (Vector3.Dot(velocity, vsplayer) > 0 && vsplayer.magnitude < 25)
            {
                hate = 1;
            }
        }
        else if (hate <= 500)
        {
            if (vsplayer.magnitude < 25)
            {
                hate += 1;

            }
        }

        if (currentBaseState.nameHash == RestState)
        {
            if (currentBaseState.nameHash != preState)
            {
                tired -= 1000;
            }
            if (tired < 0) tired = 0;
        }
        else if (currentBaseState.nameHash == RollLeftState4)
        {
            time += Time.fixedDeltaTime;
            tired += 2;
            transform.localPosition += new Vector3(-velocity.z, 0, velocity.x) * 5f * Time.fixedDeltaTime;


            transform.Rotate(Vector3.forward * 3.9f);


            if (time < 0.21)
            {
                transform.position += Vector3.up * Time.fixedDeltaTime * 2.5f;
            }
            else
            {
                transform.position += Vector3.up * Time.fixedDeltaTime * 2f;
            }
            //transform.localPosition += Vector3.down * Time.fixedDeltaTime * 3f;
        }
        else if (currentBaseState.nameHash == RollLeftState3)
        {
            tired += 2;
            //transform.localPosition += new Vector3(-velocity.z, 0, velocity.x) * 5f * Time.fixedDeltaTime;
            transform.localPosition += new Vector3(-velocity.z, 0, velocity.x) * 2f * Time.fixedDeltaTime;
            transform.Rotate(Vector3.forward * 3.5f);
            transform.localPosition += Vector3.up * Time.fixedDeltaTime * 4f;
        }
        else if (currentBaseState.nameHash == RightFindState2)
        {
            time += Time.fixedDeltaTime;
            Quaternion r = transform.rotation;
            Vector3 ra = transform.eulerAngles;
            transform.LookAt(player.transform);
            
            if (time < 0.36)
            {
                Vector3 v = new Vector3(0, transform.eulerAngles.y - ra.y, 0);
                while (v.y < 0)
                {
                    v.y += 360;
                }
                transform.rotation = r;
                transform.Rotate(v / ((0.36f - time) / Time.fixedDeltaTime));
            }
        }
        else if (currentBaseState.nameHash == LeftFindState2)
        {
            time += Time.fixedDeltaTime;
            Quaternion r = transform.rotation;
            Vector3 ra = transform.eulerAngles;
            transform.LookAt(player.transform);
            if (time < 0.36)
            {
                
                Vector3 v = new Vector3(0, (transform.eulerAngles.y - ra.y)-360, 0);
                while (v.y <= -360)
                {
                    v.y += 360;
                }
                transform.rotation = r;
                transform.Rotate(v / ((0.36f - time) / Time.fixedDeltaTime));
            }
        }
        else if (currentBaseState.nameHash == RollLeftState5)
        {
            tired += 2;
            //transform.localPosition += new Vector3(-velocity.z, 0, velocity.x) * 5f * Time.fixedDeltaTime;
            transform.Rotate(Vector3.forward * 3.5f);
            transform.position -= Vector3.up * Time.fixedDeltaTime * 1f;
            transform.position += new Vector3(-velocity.z, 0, velocity.x) * 5f * Time.fixedDeltaTime;

        }
        else if (currentBaseState.nameHash == RollLeftState6)
        {
            tired += 2;
            //transform.localPosition += new Vector3(-velocity.z, 0, velocity.x) * 5f * Time.fixedDeltaTime;
            transform.Rotate(Vector3.forward * 3.5f);
            transform.position -= Vector3.up * Time.fixedDeltaTime * 5.2f;
            transform.position += new Vector3(-velocity.z, 0, velocity.x) * 2f * Time.fixedDeltaTime;

        }
        else if (currentBaseState.nameHash == RollLeftState2)
        {
            tired += 1;
            transform.localPosition += new Vector3(-velocity.z, 0, velocity.x) * 2f * Time.fixedDeltaTime;
        }
        else if (currentBaseState.nameHash == SpeedState2)
        {
            tired += 3;
            turn_speed += 1;
            transform.Rotate(Vector3.up * turn_speed * 0.25f);
        }
        else if (currentBaseState.nameHash == SpeedState3)
        {
            tired += 3;
            turn_speed -= 1;
            transform.Rotate(Vector3.up * turn_speed * 0.25f);
        }
        else
        {
            turn_speed = 0;
        }

        if (currentBaseState.nameHash == TurnRightState4 || currentBaseState.nameHash == TurnLeftState4)
        {
            tired += 1;

            transform.LookAt(player.transform);
            float z = transform.eulerAngles.z;
            transform.Rotate(-Vector3.forward * z);
            float x = transform.eulerAngles.x;
            transform.Rotate(-Vector3.up * x);
        }
        if (currentBaseState.nameHash == MoveState)
        {
            tired += 2;
            time += Time.fixedDeltaTime;
            if (time < 0.6)
            {
                transform.localPosition += velocity * 4.5f * Time.fixedDeltaTime;
            }
            if (cos < 0.9)
            {
                if (direction < 0)
                {
                    transform.Rotate(Vector3.down * 50 * Time.fixedDeltaTime);
                }
                else if (direction > 0)
                {
                    transform.Rotate(Vector3.up * 50 * Time.fixedDeltaTime);
                }
            }
            if (cos < 0.2)
            {
                anim.SetBool("move", false);
            }
        }
        else if (currentBaseState.nameHash == DownState)
        {

            anim.SetBool("down", false);
            if(currentBaseState.nameHash != preState)
            {
                downTime++;
            }
            time += Time.fixedDeltaTime;
            if (time < 0.5)
            {
                transform.localPosition += new Vector3(0.0f, 1.0f, 0.0f) * 3f * Time.fixedDeltaTime;
                transform.Rotate(Vector3.left * 190f * Time.fixedDeltaTime);

            }
            else if (time > 3.5)
            {

                if (transform.position.y > posy) transform.localPosition -= new Vector3(0.0f, 1.0f, 0.0f) * 1.5f * Time.fixedDeltaTime;
                if (transform.rotation.x < rotx) transform.Rotate(Vector3.right * 75f * Time.fixedDeltaTime);
            }
            else if (!hasDrop)
            {
                prefab = Instantiate(drop, drop_point.transform.position, Quaternion.identity);
                prefab.transform.Rotate(new Vector3(-90, 0, 0));
                hasDrop = true;
            }


        }
        else if (currentBaseState.nameHash == DeadState)
        {
            transform.Find("Sphere003").gameObject.SetActive(false);
            anim.SetBool("down", false);
            anim.SetBool("dead", false);
        }
        else if (currentBaseState.nameHash == TukamiState2)
        {
            tired += 2;
            if (tukanda)
            {
                player.transform.position = tukami_point.transform.position;
            }
            breath.enableEmission = true;
        }
        else if (currentBaseState.nameHash == TukamiState1)
        {
            tired += 1;
            if (tukanda)
            {
                float x = tukami_point.transform.position.x;
                float y = player.transform.position.y;
                float z = tukami_point.transform.position.z;
                player.transform.position = new Vector3(x, y, z);
            }
        }
        else if (currentBaseState.nameHash == TukamiState3)
        {
            tired += 1;
            if (tukanda)
            {
                player.transform.position = tukami_point.transform.position;
            }
            tukanda = false;
        }
        else if (currentBaseState.nameHash == BreathState2)
        {
            tired += 2;
            breath.enableEmission = true;
        }
        else if (currentBaseState.nameHash == TurnLeftState2)
        {
            System.Random random = new System.Random();
            if (hate <= 20 && !kaku)
            {
                int r = random.Next(0, 100);
                if (r < 50)
                {
                    anim.SetBool("owaru", true);
                }
                kaku = true;
            }
            tired += 1;
            anim.SetBool("turn_left", false);
            transform.Rotate(Vector3.down * 75f * Time.fixedDeltaTime);
        }
        else if (currentBaseState.nameHash == WalkState0 || currentBaseState.nameHash == WalkState1 || currentBaseState.nameHash == WalkState2)
        {
            System.Random random = new System.Random();
            if (hate <= 20 && !kaku)
            {
                int r = random.Next(0, 100);
                if (r < 50)
                {
                    anim.SetBool("walk", false);
                }
                kaku = true;
            }
            tired += 1;
            transform.localPosition += velocity * 2.5f * Time.fixedDeltaTime;
            if (cos < 0.9 && hate > 20)
            {
                if (direction < 0)
                {
                    transform.Rotate(Vector3.down * 50 * Time.fixedDeltaTime);
                }
                else if (direction > 0)
                {
                    transform.Rotate(Vector3.up * 50 * Time.fixedDeltaTime);
                }
            }
            if ((cos < 0.2 && hate > 20) || vsplayer.magnitude < 5)
            {
                anim.SetBool("walk", false);
            }
        }
        else if (currentBaseState.nameHash == TurnRightState2)
        {
            System.Random random = new System.Random();
            if (hate <= 20 && !kaku)
            {
                int r = random.Next(0, 100);
                if (r < 50)
                {
                    anim.SetBool("owaru", true);
                }
                kaku = true;
            }
            tired += 1;
            anim.SetBool("turn_right", false);
            transform.Rotate(Vector3.up * 75f * Time.fixedDeltaTime);
        }
        else if (currentBaseState.nameHash == BackState0)
        {

            if (preState != BackState0)
            {
                posy = transform.position.y;
                rotx = transform.rotation.x;
                rot = transform.rotation;
            }
            transform.Rotate(Vector3.right * 35f * Time.fixedDeltaTime);
        }
        else if (currentBaseState.nameHash == BackState1)
        {
            transform.localPosition -= new Vector3(velocity.x, 0, velocity.z) * 5 * Time.fixedDeltaTime;
            tired += 2;
        }
        else if (currentBaseState.nameHash == BackState2)
        {
            transform.Rotate(Vector3.left * 35f * Time.fixedDeltaTime);
        }

        else if (currentBaseState.nameHash == IdleState)
        {

            float x = transform.position.x;
            float z = transform.position.z;
            transform.position = new Vector3(x, ini_y, z);

            if (preState == DownState)
            {
                Vector3 np = new Vector3(transform.position.x, posy, transform.position.z);
                transform.position = np;
                transform.rotation = rot;
            }
            if (preState == BackState2)
            {
                Vector3 np = new Vector3(transform.position.x, posy, transform.position.z);
                transform.position = np;
                transform.rotation = rot;
            }
            if (preState == RollLeftState6)
            {
                z = transform.eulerAngles.z;
                transform.Rotate(new Vector3(0, 0, -z));

                rest = true;
            }
            if (tired > 2000) tired = 2000;
            else if (tired < 0) tired = 0;
            System.Random random = new System.Random();
            if (tired > random.Next(0, 2000))
            {
                rest = true;
            }
            if (rest)
            {
                anim.SetBool("rest", true);
            }
            else if (hate <= 20 && !kaku)
            {
                int r = random.Next(0, 100);
                if (r < 20)
                {
                    anim.SetBool("walk", true);
                    kaku = true;
                }
                else if (r < 40)
                {
                    anim.SetBool("turn_left", true);
                    kaku = true;
                }
                else if (r < 60)
                {
                    kaku = true;
                    anim.SetBool("turn_right", true);
                }
            }
            else if (hate > 300 && cos < 0.8 && random.Next(0, 100) < 50)
            {
                anim.SetBool("speed_turn", false);
                anim.SetBool("tukami", false);
                anim.SetBool("roll_left", false);
                anim.SetBool("whip_left", false);
                anim.SetBool("back", false);
                if (direction < 0)
                {
                    anim.SetBool("back", false);
                    anim.SetBool("turn_left", false);
                    anim.SetBool("left_find", true);
                }
                else if (direction > 0)
                {
                    anim.SetBool("turn_right", false);
                    anim.SetBool("right_find", true);
                }
            }
            else if (hate > 200 && vsplayer.magnitude < 5 && cos < -0.2)
            {
                anim.SetBool("back", true);
            }
            else if (hate > 20 && vsplayer.magnitude < 5 && cos < 0.9 && cos > 0.2 && direction < 0)
            {
                anim.SetBool("whip_left", true);
            }
            else if (hate > 40 && vsplayer.magnitude < 15 && cos < 0.5 && cos > -0.5 && direction < 0)
            {
                anim.SetBool("roll_left", true);
            }
            else if (hate > 20 && vsplayer.magnitude < 5 && cos < 0.9 && cos > 0.2 && direction > 0)
            {
                anim.SetBool("tukami", true);
            }
            else if (hate > 20 && cos > 0.95 && vsplayer.magnitude < 20)
            {
                anim.SetBool("breath", true);
            }

            else if (hate >= 500 && vsplayer.magnitude < 6)
            {
                anim.SetBool("speed_turn", true);
            }

            else if (hate >= 200 && (cos < 0.9))
            {
                if (direction < 0)
                {
                    anim.SetBool("turn_left", true);
                }
                else if (direction > 0)
                {
                    anim.SetBool("turn_right", true);
                }
            }
            else if (hate > 200 && cos > 0.5 && vsplayer.magnitude > 20)
            {
                anim.SetBool("move", true);
            }
            else if (hate > 20 && cos > 0.95 && vsplayer.magnitude > 20)
            {
                anim.SetBool("walk", true);
            }
        }

        preState = currentBaseState.nameHash;

    }
    public void GetDamage(int bui, int damage, int special_type, int special_damage)
    {
        HP -= (damage / DEF[bui]);
        hate += damage;
        if (special_type < 10)
        {
            Special[special_type] += special_damage;
        }
        else if (special_type == 10)
        {
            HP -= (special_damage / fireDEF[bui]);
        }
        else if (special_type == 11)
        {
            HP -= (special_damage / iceDEF[bui]);
        }
    }
    /*public void hit(int bui)
    {
        if (bui > 0)
        {
            if (!hashit)
            {
                hashit = true;
                if (currentBaseState.nameHash == LeftFindState2 && bui == 2)
                {
                    hate -= 150;
                    player.GetComponent<UnityChanControlScriptWithRgidBody>().getDamage(15, gameObject);
                }
                else if (currentBaseState.nameHash == WhipState && bui == 2)
                {
                    hate -= 150;
                    player.GetComponent<UnityChanControlScriptWithRgidBody>().getDamage(15, gameObject);
                }
                else if (currentBaseState.nameHash == RightFindState2 && bui == 3)
                {
                    hate -= 150;
                    player.GetComponent<UnityChanControlScriptWithRgidBody>().getDamage(15, gameObject);
                }
                else if ((currentBaseState.nameHash == SpeedState2 || currentBaseState.nameHash == SpeedState3) && (bui == 2 || bui == 3))
                {
                    hate -= 300;
                    player.GetComponent<UnityChanControlScriptWithRgidBody>().getDamage(15, gameObject);
                }
                else if ((currentBaseState.nameHash == RollLeftState2 || currentBaseState.nameHash == RollLeftState3 || currentBaseState.nameHash == RollLeftState4 || currentBaseState.nameHash == RollLeftState5 || currentBaseState.nameHash == RollLeftState6) && bui == 1)
                {
                    hate -= 250;
                    player.GetComponent<UnityChanControlScriptWithRgidBody>().getDamage(25, gameObject);
                }
                else if (currentBaseState.nameHash == BackState1 && bui == 1)
                {
                    hate -= 250;
                    player.GetComponent<UnityChanControlScriptWithRgidBody>().getDamage(25, gameObject);
                }
                else if (currentBaseState.nameHash == TukamiState1 && bui == 3)
                {
                    tukanda = true;
                    anim.SetBool("atari", true);
                    hate -= 50;
                    eventsystem.GetComponent<BarSystem>().ControlHP(5);
                }
                else if (currentBaseState.nameHash == MoveState && bui == 1)
                {
                    hate -= 300;
                    player.GetComponent<UnityChanControlScriptWithRgidBody>().getDamage(30, gameObject);
                }
            }
        }
        else if (!hashit)
        {
            hashit = true; 
            if (currentBaseState.nameHash == LeftFindState2 && bui == -2)
            {
                eventsystem.GetComponent<BarSystem>().ControlEnerge(15);
            }
            else if (currentBaseState.nameHash == WhipState && bui == -2)
            {
                eventsystem.GetComponent<BarSystem>().ControlEnerge(15);
            }
            else if (currentBaseState.nameHash == RightFindState2 && bui == -3)
            {
                eventsystem.GetComponent<BarSystem>().ControlEnerge(15);
            }
            else if ((currentBaseState.nameHash == SpeedState2 || currentBaseState.nameHash == SpeedState3) && (bui == -2 || bui == -3))
            {
                eventsystem.GetComponent<BarSystem>().ControlEnerge(15);
            }
            else if ((currentBaseState.nameHash == RollLeftState2 || currentBaseState.nameHash == RollLeftState3 || currentBaseState.nameHash == RollLeftState4 || currentBaseState.nameHash == RollLeftState5 || currentBaseState.nameHash == RollLeftState6) && bui == -1)
            {
                eventsystem.GetComponent<BarSystem>().ControlEnerge(25);
            }
            else if (currentBaseState.nameHash == BackState1 && bui == -1)
            {
                eventsystem.GetComponent<BarSystem>().ControlEnerge(25);
            }
            else if (currentBaseState.nameHash == TukamiState1 && bui == -3)
            {
                eventsystem.GetComponent<BarSystem>().ControlEnerge(5);
            }
            else if (currentBaseState.nameHash == MoveState && bui == -1)
            {
                eventsystem.GetComponent<BarSystem>().ControlEnerge(30);
            }
        }
        
    }
    public void blocked()
    {
        hashit = true;
    }*/
}
