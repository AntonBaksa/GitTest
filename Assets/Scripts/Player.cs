using UnityEngine;

public class Player : MonoBehaviour
{
    public float thrustspeed = 1.0f;
    public float turnspeed = 1.0f;
    private Rigidbody2D _rigitbody; 
    private bool _thrusting;
    private float _turndirection;

    private void Awake()
    {
        _rigitbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _thrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            _turndirection = 1.0f;
        }else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            _turndirection = - 1.0f;
        }
        else {
            _turndirection = 0.0f;  
        }
    }

    private void FixedUpdate()
    {
        if (_thrusting) {
            _rigitbody.AddForce(this.transform.up * thrustspeed);
        }
        if(_turndirection != 0.0f) {
            _rigitbody.AddTorque(_turndirection * this.turnspeed);  
        }
    }
}

