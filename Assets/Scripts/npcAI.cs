using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class npcAI : MonoBehaviour
{
    public enum FSMStates
    {
        Idle,
        Walk,
        //Run
    }

    public AudioClip meow;
    private AudioSource audioSource;
    public float waitTime = 1.0f;
    public FSMStates currentState;
    public GameObject player;
    public float walkSpeed = 3.5f;
    public float runSpeed = 6.0f;
    public float chaseDistance = 10.0f;
    public float stoppingDistance = 1.0f;

    GameObject[] wanderPoints;
    Vector3 nextDestination;
    int currentDestinationIndex = 0;
    NavMeshAgent agent;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        wanderPoints = GameObject.FindGameObjectsWithTag("WanderPoint");
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        switch (currentState)
        {
            case FSMStates.Idle:
                UpdateIdleState();
                break;
            case FSMStates.Walk:
                UpdateWalkState(distanceToPlayer);
                break;
            //case FSMStates.Run:
            //    UpdateRunState(distanceToPlayer);
            //    break;
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    CatClicked();
                }
            }
        }
    }

    void Initialize()
    {
        currentState = FSMStates.Idle;
        FindNextPoint();
    }

    void UpdateIdleState()
    {
        anim.SetInteger("animState", 0);
        currentState = FSMStates.Walk;
    }

    void UpdateWalkState(float distanceToPlayer)
    {
        //if (distanceToPlayer <= chaseDistance)
        //{
        //    currentState = FSMStates.Run;
        //    agent.speed = runSpeed;
        //}
        //else
        //{
            currentState = FSMStates.Walk;
            agent.speed = walkSpeed;
        //}

        if (Vector3.Distance(transform.position, nextDestination) < stoppingDistance)
        {
            if (!IsInvoking("FindNextPoint"))
            {
                Invoke("FindNextPoint", waitTime);
            }
        }


        anim.SetInteger("animState", 1);
        agent.SetDestination(nextDestination);
    }

    //void UpdateRunState(float distanceToPlayer)
    //{
    //    if (distanceToPlayer > chaseDistance)
    //    {
    //        currentState = FSMStates.Walk;
    //        agent.speed = walkSpeed;
    //    }
    //    else
    //    {
    //        currentState = FSMStates.Run;
    //        agent.speed = runSpeed;
    //        agent.SetDestination(player.transform.position);
    //    }

    //    anim.SetInteger("animState", 2);
    //}

    void FindNextPoint()
    {
        currentDestinationIndex = Random.Range(0, wanderPoints.Length);
        nextDestination = wanderPoints[currentDestinationIndex].transform.position;
    }

    
    //TODO: add logic about what should we do when player click the cat
    void CatClicked()
    {
        PlayMeowSound();
    }

    void PlayMeowSound()
    {
        if (meow != null && audioSource != null)
        {
            audioSource.PlayOneShot(meow);
        }
    }
}
