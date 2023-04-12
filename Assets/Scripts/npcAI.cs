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
        LeadPlayer,
        Stop,
        Purr
    }

    public AudioClip purr;
    public AudioClip meow;
    public float idleDistance = 1.0f;
    public float waitTime = 1.0f;
    public bool canWander = false;
    public GameObject player;
    public float walkSpeed = 3.5f;
    public float runSpeed = 6.0f;
    public float chaseDistance = 10.0f;
    public float stoppingDistance = 1.0f;
    public GameObject firstPuzzleDestination;

    private AudioSource audioSource;
    private bool reachedDestination = false;
    private FSMStates currentState;
    private bool isPurr = false;
    


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
                UpdateIdleState(distanceToPlayer);
                break;
            case FSMStates.Walk:
                UpdateWalkState(distanceToPlayer);
                break;
            case FSMStates.LeadPlayer:
                UpdateLeadPlayerState();
                break;
            case FSMStates.Stop:
                UpdateStopState();
                break;
            case FSMStates.Purr:
                UpdatePurrState(distanceToPlayer);
                break;
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

    void UpdatePurrState(float distanceToPlayer)
    {
        anim.SetInteger("animState", 0);
        agent.ResetPath();
        if (!isPurr) {
        playPurrSound();

        }

        if (distanceToPlayer > idleDistance)
        {
            stopPurrSound();
            currentState = FSMStates.Walk;
        }
  
    }



    void Initialize()
    {
        currentState = FSMStates.Idle;
        FindNextPoint();
    }

    void UpdateIdleState(float distanceToPlayer)
    {
        anim.SetInteger("animState", 0);
        canWander = true;
        if (distanceToPlayer <= idleDistance)
        {
            currentState = FSMStates.Purr;
        }
        else if (distanceToPlayer > idleDistance)
        {
            currentState = FSMStates.Walk;
        }
    }

    private void playPurrSound()
    {
        if (purr != null && audioSource != null)
        {
            audioSource.clip = purr;
            audioSource.loop = true;
            audioSource.Play();
            isPurr = true;
        }
    }

    private void stopPurrSound()
    {
        if (audioSource != null && audioSource.isPlaying && audioSource.clip == purr)
        {
            audioSource.Stop();
            isPurr = false;
        }
    }


    void UpdateStopState()
    {
        anim.SetInteger("animState", 0);
        agent.ResetPath();
    }


    void UpdateWalkState(float distanceToPlayer)
    {

        if (distanceToPlayer <= idleDistance)
        {
            currentState = FSMStates.Purr;
            agent.ResetPath();
            return;
        }

        anim.SetInteger("animState", 1);


        if (currentState != FSMStates.LeadPlayer)
        {
            currentState = FSMStates.Walk;
            agent.speed = walkSpeed;

            if (canWander)
            {
                if (Vector3.Distance(transform.position, nextDestination) < stoppingDistance)
                {
                    if (!IsInvoking("FindNextPoint"))
                    {
                        Invoke("FindNextPoint", waitTime);
                    }
                }
            }

            anim.SetInteger("animState", 1);
            if (canWander)
            {
                agent.SetDestination(nextDestination);
            }
        }

        if (reachedDestination)
        {
            currentState = FSMStates.Stop;
        }
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
        if (currentState == FSMStates.LeadPlayer)
        {
            return;
        }

        currentDestinationIndex = Random.Range(0, wanderPoints.Length);
        nextDestination = wanderPoints[currentDestinationIndex].transform.position;
    }




    void CatClicked()
    {
        InventorySystemScript inventory = FindObjectOfType<InventorySystemScript>();
        if (inventory.HasPetFood())
        {
            GameObject petFood = inventory.GetCurrentObject();
            if (petFood != null && petFood.GetComponent<InteractableScript>().isPetFood)
            {
                currentState = FSMStates.Stop;
                LeadPlayerToFirstPuzzle();
                inventory.removeFromInventory(petFood);
                PlayMeowSound();
            }
        }
    }





    void PlayMeowSound()
    {
        if (meow != null && audioSource != null)
        {
            audioSource.PlayOneShot(meow);
        }
    }

    public void LeadPlayerToFirstPuzzle()
    {
        canWander = false;
        reachedDestination = false;
        currentState = FSMStates.LeadPlayer;
    }





    void UpdateLeadPlayerState()
    {
        float distanceToDestination = Vector3.Distance(transform.position, firstPuzzleDestination.transform.position);

        if (distanceToDestination <= stoppingDistance && !reachedDestination)
        {
            reachedDestination = true;
            currentState = FSMStates.Idle;
            anim.SetInteger("animState", 0);
            agent.ResetPath();
        }
        else if (!reachedDestination)
        {
            anim.SetInteger("animState", 1);
            agent.speed = walkSpeed;
            agent.SetDestination(firstPuzzleDestination.transform.position);
        }
    }

    public bool isCathere()
    {
        return reachedDestination;
    }


}
