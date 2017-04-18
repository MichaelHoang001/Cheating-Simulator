using UnityEngine;
using System.Collections;

public class TeacherMovement : MonoBehaviour {
    public Vector3 teacherDefaultPosition;
    public Quaternion teacherDefaultRotation;
    public float speed = 1;
    public Quaternion position1;
    public Quaternion position2;
    public Quaternion position3;
    public Quaternion position4;
    public Quaternion position5;
    public RayCaster raycaster;
    public bool turnClockwise_flag = false;
    public bool turnCounterClockwise_flag = true;
    public int time_interval = 3;
    public GameObject teacher_obj;
    public bool off = false;
    public bool on = true;
    public bool isSuspicious = false;
    public int EraserAttention = 0;
    public Vector3 EraserLocation;
    //for moving around the room
    public Transform[] targets;
    UnityEngine.AI.NavMeshAgent agent;
    public int pathpoint;
    public Animator anim;
    public GameObject player;
    public int counter = 0;
    // Use this for initialization
    void Start() {
        /*Saving the default position*/
        teacherDefaultPosition = transform.position;
        teacherDefaultRotation = transform.rotation;
        position1 = Quaternion.Euler(0, 90, 0);
        position2 = Quaternion.Euler(0, -90, 0);
        position3 = Quaternion.Euler(0, 270, 0);
        position4 = Quaternion.Euler(0, 300, 0);
        position5 = Quaternion.Euler(0, 80, 0);

        //for moving around the room
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        pathpoint = 0;  //go to first target initially

        anim = GetComponent<Animator>();
        agent.Stop();
    }

    public bool gamestarted = false;
    // Update is called once per frame
    void Update() {
        if (gamestarted) {
            //for moving around the room
            agent.SetDestination(targets[pathpoint].position); //move towards target

            if (isSuspicious) {// just became suspicious - look at player until not suspicious
                stareAt(player.transform.position);
            } else if (EraserAttention > 0) {
                stareAt(EraserLocation);
            } else { // normal actions
                if (savingPos)
                    savingPos = false;
                if (off) {
                    teacher_obj.GetComponent<UnityEngine.AI.NavMeshAgent>().Stop();
                    // anim.Play("idle_10", -1, 0f);
                    anim.SetBool("isWalking", true);
                    teacherLookaround();
                }
                if (!off) {
                    teacher_obj.GetComponent<UnityEngine.AI.NavMeshAgent>().Resume();
                    //  anim.Play("walk_00", -1, 0f);
                    anim.SetBool("isWalking", false);
                }
                if (on) {
                    StartCoroutine(Stop_look());
                }
            }

            //eraser attention decay regardless of actions taken
            if (EraserAttention > 0) {
                EraserAttention -= 1;
            } else (EraserAttention < 0){
                EraserAttention = 0;
            }
        }
    }

    Vector3 lockedPosition = new Vector3(0, 0, 0);
    bool savingPos = false;
    private void stareAt (Vector3 target) {
        if (!savingPos) {
            lockedPosition = transform.position;
            savingPos = true;
        }
        else {
            transform.position = lockedPosition; // workaround for demonic sliding teacher of doom
        }
        teacher_obj.GetComponent<UnityEngine.AI.NavMeshAgent>().Stop();
        anim.SetBool("isWalking", true);
        Quaternion _lookRotation = Quaternion.LookRotation((target - transform.position).normalized);
        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * speed);
    }

    public void NextPoint(int go_here) {
        pathpoint = go_here;
        //Debug.Log("path point changed to " + pathpoint);
    }


    IEnumerator Stop_look() {
        counter++;
        on = false;

        yield return new WaitForSeconds(time_interval); //This makes the function wait before returning to update function to start another cycle

        off = !off;
        on = true;
    }


    public void teacherLookaround() {

        Quaternion current = transform.rotation;

        /*The teacher's movement of vision is hardcoded here depending on what way point he is currently stopped at
           this is kept track by the counter variable. It is reset back to 0 when it does a full cycle.*/
        if (counter <= 4) { transform.rotation = Quaternion.Slerp(current, position2, Time.deltaTime * speed); }

        if (counter >= 5 && counter < 14) { transform.rotation = Quaternion.Slerp(current, position1, Time.deltaTime * speed); }

        if (counter >= 14) { counter = 0; }
    }
}