using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BugState{
    Idle,
    Wander,
    Run
}

public class Bug : MonoBehaviour
{

    public Player player;

    public Animator anim;

    public Vector2 velocity;
    public Rigidbody2D rigid;

    public Vector2 wanderTarget;
    public float wanderRange = 5f;

    public float wanderForce = 4f;
    public float runForce = 8f;

    public BugState state = BugState.Idle;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wander());
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")){
            player = collision.gameObject.GetComponent<Player>();
            // Run
            StartCoroutine( Run((Vector2)player.transform.position));
        }
    }

    public IEnumerator Idle(){
        anim.SetBool("isIdle", true);
        anim.SetBool("isWander", false);
        state = BugState.Idle;

        yield return new WaitForSeconds(3f);
        StartCoroutine(Wander());
    }

    public IEnumerator Wander(){

        anim.SetBool("isIdle", false);
        anim.SetBool("isWander", true);
        state = BugState.Wander;

        wanderTarget = (Vector2)transform.position + Random.insideUnitCircle * wanderRange;

        yield return new WaitForSeconds(2f);

        StartCoroutine(Idle());
    }

    public void FixedUpdate() {
        if(state == BugState.Wander){
            Vector2 pathVector = wanderTarget - (Vector2)transform.position;
            pathVector.Normalize();
            rigid.AddForce(pathVector * wanderForce);
            Debug.DrawRay(transform.position, pathVector * wanderForce); // should be inverse of vector to player. 
        }
    }

    public IEnumerator Run(Vector2 runFromPoint){

        StopAllCoroutines();
        anim.SetBool("isRun", true);

        state = BugState.Run;

        Vector2 runVector = runFromPoint - (Vector2)transform.position;
        runVector = runVector * -1f;
        rigid.AddForce(runVector.normalized * runForce, ForceMode2D.Impulse);
        Debug.DrawRay(transform.position, runVector); // should be inverse of vector to player. 


        yield return new WaitForSeconds(4f);


        StartCoroutine(Wander());
    }

    // Update is called once per frame
    void Update()
    {
        velocity = rigid.velocity;
        if(velocity.x > 0.1f || velocity.x < -0.1f)
            anim.SetFloat("xVelocity", velocity.x);
        if(velocity.y > 0.1f || velocity.y < -0.1f)
            anim.SetFloat("yVelocity", velocity.y);
    }

    
}
