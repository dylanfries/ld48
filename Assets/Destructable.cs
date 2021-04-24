using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Destructable : MonoBehaviour
{
    public SpriteRenderer render;
    public Sprite[] sprites;
    public int currentLevel;
    public UnityEvent hitEvent = new UnityEvent();

    public bool randomizeDamage = false;


    public bool DEBUG_MODE = false;

    private void Start() {
        if(randomizeDamage){
            int rand = Random.Range(0, sprites.Length - 1);
            Debug.Log("Lenght; " + sprites.Length + " rand: " + rand);
            currentLevel = rand;
        }

        render.sprite = sprites[currentLevel];
    }

    //
    private void OnTriggerEnter2D(Collider2D collision) {
        if(DEBUG_MODE) { Debug.Log(gameObject.name + " hit by " + collision.name); }

        // only player should hit it?
            if (currentLevel > 0){
            currentLevel--;
            render.sprite = sprites[currentLevel];
            hitEvent.Invoke();
        }

    }
}
