using UnityEngine;
using System.Collections;

public class TransformObject:MonoBehaviour {

    public bool Open;//открыт ли он
    public bool activeJump;

    public void IsOpen()
    {
        Open = true;
    }

    public void IsClose()
    {
        Open = false;
    }

    public void Transparence()//невидимость
    {
        //GetComponent<BoxCollider2D>().enabled = false;
        gameObject.SetActive(false);
    }

    public void UnTransparence()//видимость
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)//мега прыжок
    {
        StartCoroutine(MegaJump(collision));
    }

    public IEnumerator MegaJump(Collision2D collision)//реализация мега прыжка
    {
        if(activeJump)
        {
            yield return new WaitForSeconds(0.3f);
            GetComponent<Animation>().Play("Jump");
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 105),ForceMode2D.Impulse);
            activeJump = false;
        }
    }
    


}
