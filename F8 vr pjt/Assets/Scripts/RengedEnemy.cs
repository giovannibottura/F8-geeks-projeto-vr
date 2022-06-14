using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class RengedEnemy : MonoBehaviour
{
    public HealthBarScrip PlayerUi;
    public EnemyHealthBar HealthBar;
    public Player Player;
    public int EnemyHealth;
    public int MaxEnemyHealth;
    
    public GameObject arrowstart;

    public Animator animRengeEnemy;

    public GameObject enemy;

    public NavMeshAgent ThisAgent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;


    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    public bool alreadyAttacked;
    public GameObject projectile;

    //Statesa
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public bool Canfire;
    private void Awake()
    {
        player = GameObject.Find("OVRPlayerController").transform;
        ThisAgent = GetComponent<NavMeshAgent>();
       
        HealthBar.setmaxhealth(MaxEnemyHealth);
        EnemyHealth = MaxEnemyHealth;
    }

    private void Update()
    {   

        if (animRengeEnemy.GetCurrentAnimatorStateInfo(0).IsName("Fire")){
            Canfire = true;
        }
        if(EnemyHealth <= 0){
            PlayerUi.Points = PlayerUi.Points + 1; 
            Destroy(gameObject);
        }
        HealthBar.sethealth(EnemyHealth);  

        
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            ThisAgent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        ThisAgent.SetDestination(player.position);
        transform.LookAt(player);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        ThisAgent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            
            enemy.GetComponent<Animator>().Play("Charge");
            
            if(animRengeEnemy.GetCurrentAnimatorStateInfo(0).IsName("Fire")){   
                Rigidbody rb = Instantiate(projectile, arrowstart.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * 50f, ForceMode.Impulse);
                rb.AddForce(transform.up * 4f, ForceMode.Impulse);
                

                alreadyAttacked = true;
                Canfire = false;
                Invoke(nameof(ResetAttack), timeBetweenAttacks);
            }
           
        }
    }
    public void ResetAttack()
    {
        alreadyAttacked = false;
        Canfire = false;
    }
    void OnTriggerEnter (Collider other){
        if(other.tag == "PlayerWeapon"){
            enemy.GetComponent<Animator>().Play("EnemyHurt");
            EnemyHealth = EnemyHealth - 1;
            GetComponent<NavMeshAgent>().speed = 0;
          //  StartCoroutine(ExampleCoroutine());
            HealthBar.sethealth(EnemyHealth);
        }
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

}
