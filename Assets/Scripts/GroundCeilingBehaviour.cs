using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCeilingBehaviour : MonoBehaviour
{
    Rigidbody2D _boundary;
    [SerializeField] PlayerBehaviour _PlayerBehaviour;
    // Start is called before the first frame update
    void Start()
    {
        _boundary = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (!_PlayerBehaviour._isJover){
        _boundary.velocity = new Vector2(3f, _boundary.velocity.y);
        }
        else{
            _boundary.velocity = Vector2.zero;
        }
    }
}
