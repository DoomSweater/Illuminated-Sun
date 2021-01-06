using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;

    [SerializeField]
    private float speed = 7.5f;
    [SerializeField]
    private float gravity = 0.3f;
    [SerializeField]
    private float jumpHeight = 15.0f;
    private float _yVelocity;
    private bool _canDoubleJump = false;
    //variable for playersouls
    
    [SerializeField]
    private int _souls;
    private UIManager _uiManager;



    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if(_uiManager == null)
        {
            Debug.LogError("The UI Manager is NULL");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        Vector3 velocity = direction * speed;

        if (_controller.isGrounded == true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = jumpHeight;
                _canDoubleJump = true; 
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(_canDoubleJump == true)
                {
                    _yVelocity += jumpHeight;
                    _canDoubleJump = false;
                }
                
            }
            _yVelocity -= gravity;
        }

        velocity.y = _yVelocity;

        _controller.Move(velocity * Time.deltaTime);

    }

    public void AddSouls()
    {
        _souls++;

        _uiManager.UpdateSoulDisplay(_souls);
    }
}
