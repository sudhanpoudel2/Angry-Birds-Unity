
using System;
using System.Collections;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] float force = 500;
    [SerializeField] float maxDragDistance = 5;

     Vector2 _startPosition;
    Rigidbody2D _body;
    SpriteRenderer _renderer;

     void Awake()
    {
        _body = GetComponent<Rigidbody2D>(); 
        _renderer = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _startPosition = _body.position;
        _body.isKinematic = true;
    }

     void OnMouseDown()
    {
        Debug.Log("Hello");
        _renderer.color = Color.red;
    }

    void OnMouseUp()
    {
        Vector2 currentPosition = _body.position;
        Vector2 direction = _startPosition - currentPosition;
        direction.Normalize();

        _body.isKinematic = false;
        _body.AddForce(direction * force);

        _renderer.color = Color.white;
    }

    void OnMouseDrag()
    {
       Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 desiredPosition = mousePosition;
        float distane =  Vector2.Distance (desiredPosition , _startPosition);
        if(distane > maxDragDistance)
        {
            Vector2 distance = desiredPosition - _startPosition;
            distance.Normalize();
            desiredPosition = _startPosition + (distance * maxDragDistance);
        }
        if (desiredPosition.x > _startPosition.x)
            desiredPosition.x = _startPosition.x;

        _body.position = desiredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(ResetAfterDelay());   
    }
    IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(3);
        _body.position = _startPosition;
        _body.isKinematic = true;
        _body.velocity = Vector2.zero;
    }
}
