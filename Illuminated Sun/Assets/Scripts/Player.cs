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

    //SOULS PREFABS
    [SerializeField]
    private GameObject darienPrefab;

    [SerializeField]
    private GameObject lilithPrefab;

    [SerializeField]
    private GameObject genePrefab;

    //Spawn Stuff
    [SerializeField]
    private float spawnRate = 5.0f;
    private float canSummon = -1f;

    [SerializeField]
    private GameObject soulContainer;

    // Instantiated character objects
    private GameObject darien;
    private GameObject lilith;
    private GameObject gene;


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

        Movement();


        if(Input.GetKeyDown(KeyCode.Alpha1) && Time.time > canSummon)
        {
            Debug.Log("Darien Summoned");

            canSummon = Time.time + spawnRate;
            darien = Instantiate(darienPrefab, transform.position + new Vector3(-1.3f, 2, 0), Quaternion.identity);
            darien.transform.parent = soulContainer.transform;
            Invoke(nameof(DestroyDarien), 5f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && Time.time > canSummon)
        {
            Debug.Log("Lilith Summoned");

            canSummon = Time.time + spawnRate;
            lilith = Instantiate(lilithPrefab, transform.position + new Vector3(-1.3f, 2, 0), Quaternion.identity);
            lilith.transform.parent = soulContainer.transform;
            Invoke(nameof(DestroyLilith), 5f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && Time.time > canSummon)
        {
            Debug.Log("Gene Summoned");

            canSummon = Time.time + spawnRate;
            gene = Instantiate(genePrefab, transform.position + new Vector3(-1.3f, 2, 0), Quaternion.identity);
            gene.transform.parent = soulContainer.transform;
            Invoke(nameof(DestroyGene), 5f);
        }


    }

    public void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        Vector3 velocity = direction * speed;

        if (_controller.isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = jumpHeight;
                _canDoubleJump = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_canDoubleJump == true)
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

    private void DestroyDarien()
    {
        Destroy(darien);
    }

    private void DestroyLilith()
    {
        Destroy(lilith);
    }

    private void DestroyGene()
    {
        Destroy(gene);
    }
}
