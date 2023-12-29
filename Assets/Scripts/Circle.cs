using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    [SerializeField] private GameObject spriteObj;
    [SerializeField] private AudioClip clickSound;
    [SerializeField] private float lifeTime = 1f;

    private bool wasClicked = false;
    private Animator anim;

    private void Start()
    {
        anim = spriteObj.GetComponent<Animator>();
        StartCoroutine(DestroyRoutine());
    }

    void OnMouseDown(){
        if(Time.timeScale > 0){
            if(!wasClicked){
                wasClicked = true;
                AudioManager.instance.PlayOneShot(clickSound);
                MainSceneManager.instance.AddScore();
                StartCoroutine(DestroyCircle());
            }
        }
    }

    private IEnumerator DestroyRoutine(){
        yield return new WaitForSeconds(lifeTime);
        StartCoroutine(DestroyCircle());
    }

    public void ChangePosition(Vector2 pos){
        transform.position = pos;
    }

    public void ChangeSize(Vector2 size){
        transform.localScale = size;
    }

    public void RandomizeColor(){
        SpriteRenderer spriteRenderer = spriteObj.GetComponent<SpriteRenderer>();
        Color newColor = Random.ColorHSV();
        spriteRenderer.color = newColor;
    }

    private IEnumerator DestroyCircle(){
        anim.SetTrigger("Destroy");
        float animClipLength = anim.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(animClipLength);
        Destroy(this.gameObject);
    }
}
