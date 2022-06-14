using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{   
    public HealthBarScrip PlayerUi;
    public EnemyHealthBar HealthBar;
    public Player Player;
   
    public EnemyWeapon EnemyWeapon;
    public GameObject enemy;
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    public int EnemyHealth;
    public int MaxEnemyHealth;
    public Animator animEnemy;
    public CapsuleCollider EnemyCollider;
    // Attacking

    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;



    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public float sightRange;
    public float attackRenge;
    public bool playerInSightRange, playerInAttackRange;


    void Start()
    {
        HealthBar.setmaxhealth(MaxEnemyHealth);
        EnemyHealth = MaxEnemyHealth;
        enemy.GetComponent<Animator>().GetBool("V1");
        enemy.GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRenge, whatIsPlayer);
        
        
        if (!playerInSightRange && !playerInAttackRange) Patroling();        
        if(playerInSightRange && !playerInAttackRange) ChasePlayer();
        if(playerInSightRange && playerInAttackRange) AttackPlayer();
        
        if(EnemyWeapon.AninDefend == false){
            animEnemy.SetBool("V1", false);
        }
        else if(EnemyWeapon.AninDefend == true){
            animEnemy.SetBool("V1", true);
            
        }

        if(EnemyHealth <= 0){
            PlayerUi.Points = PlayerUi.Points + 1; 
            Destroy(gameObject);
        }
        HealthBar.sethealth(EnemyHealth);
    }

    
    private void Awake(){
        player = GameObject.Find("OVRPlayerController").transform;
        agent = GetComponent<NavMeshAgent>();

    }
     
     
     private void Patroling()
    {
        if (!walkPointSet){ 
            SearchWalkPoint();
        }
        if (walkPointSet){
            agent.SetDestination(walkPoint);
        }
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f){
            walkPointSet = false;
        }
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 3f, whatIsGround)){
            walkPointSet = true;
        }
///        walkPointSet = true;
    }
    
    private void ChasePlayer(){
        agent.SetDestination(player.position);
        transform.LookAt(player);

    }
    private void AttackPlayer(){
        agent.SetDestination(transform.position);
        transform.LookAt(player);
        
        if (!alreadyAttacked){
            
            enemy.GetComponent<Animator>().Play("Enemy Attack");

            alreadyAttacked = true;
            animEnemy.SetBool("V1", false);
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    
    private void ResetAttack(){
        enemy.GetComponent<Animator>().Play("enemy idle");
        alreadyAttacked = false;
        
    }
    void OnTriggerEnter (Collider other){
        if(other.tag == "PlayerWeapon"){
            enemy.GetComponent<Animator>().Play("EnemyHurt");
            EnemyHealth = EnemyHealth - 1;
            GetComponent<NavMeshAgent>().speed = 0;
            StartCoroutine(ExampleCoroutine());
            HealthBar.sethealth(EnemyHealth);
        }
    }


        IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(2);
        GetComponent<NavMeshAgent>().speed = 5 ;
    }
        IEnumerator EnableColider()
    {
        yield return new WaitForSeconds(1);
        //EnemyCollider.enabled = EnableColider.enabled;
    }


}

