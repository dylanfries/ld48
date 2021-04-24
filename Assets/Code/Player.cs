using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [Header("Falling/Damage")]
    public bool isKnockedDown = false;
    public UnityEvent knockedDownEvent = new UnityEvent();
    public UnityEvent getUpEvent = new UnityEvent();
    public float getUpTimer = 1f;

    [Header("Movement")]
    public float xForce = 1f;
    public float yForce = 1f;
    public float jumpForce = 1f;

    [Header("Movement Settings")]
    private float verticalMoveRatio = 2f / 3f; // how far to move up to correspond with moving horizontal. 

    [Header("Debugging Input")]
    public Vector2 joyInput = new Vector2();


    public Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateInput();
    }

    public void UpdateInput(){
        if (isKnockedDown)
            return;

        joyInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rigid.AddForce(new Vector2(joyInput.x * xForce, joyInput.y * yForce * verticalMoveRatio ));

        if( Input.GetButtonDown("Jump")){
            Vector2 normalizedInput = joyInput.normalized;

            Vector2 baseVector = new Vector2(normalizedInput.x * xForce, normalizedInput.y * yForce * verticalMoveRatio);
            Vector2 directionVector = new Vector2 (joyInput.x * xForce, joyInput.y * yForce * verticalMoveRatio);
            rigid.AddForce((baseVector + directionVector), ForceMode2D.Impulse);
        }
    }

    public void KnockedDown(){
        if (isKnockedDown)
            return;

        knockedDownEvent.Invoke();
        StartCoroutine("GetUp");
    }

    private IEnumerable GetUp(){
        yield return new WaitForSeconds(getUpTimer);
        isKnockedDown = false;
        getUpEvent.Invoke();
    }
}
