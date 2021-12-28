using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextBird : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 startPosition;
    Vector2 endPosition;
    [SerializeField]
    float launchForce = 500;
    [SerializeField]
    float maxDragDistance = 5;
    void Start()
    {
        GetComponent<Rigidbody2D>().isKinematic = true;
    }
    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        startPosition = GetComponent<Rigidbody2D>().position;
    }
    // Update is called once per frame\
    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        endPosition = GetComponent<Rigidbody2D>().position;
        Vector2 direction = endPosition - startPosition;
        direction.Normalize();
        GetComponent<Rigidbody2D>().isKinematic = false;
        GetComponent<Rigidbody2D>().AddForce(-direction * launchForce);

    }
    private void OnMouseDrag()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //transform.position = new Vector3(mousePos.x,mousePos.y,transform .position .z );
        Vector2 desiredPosition = mousePos;

        float distance = Vector2.Distance(desiredPosition, startPosition);
        if (distance > maxDragDistance)
        {
            Vector2 direction = desiredPosition - startPosition;
            direction.Normalize();
            desiredPosition = startPosition + (direction * maxDragDistance);
        }
        if (desiredPosition.x > startPosition.x)
        {
            desiredPosition.x = startPosition.x;
        }
        GetComponent<Rigidbody2D>().position = desiredPosition;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Monster")
        {
            StartCoroutine(ResestAfterDelay());
        }
        else
        {
            this.gameObject.SetActive(false);
            transform.GetChild(0).gameObject.SetActive(true);
            StartCoroutine(ResestAfterDelay());
        }
    }
    IEnumerator ResestAfterDelay()
    {
        yield return new WaitForSeconds(3);
        GetComponent<Rigidbody2D>().position = startPosition;
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    void Update()
    {

    }
}
