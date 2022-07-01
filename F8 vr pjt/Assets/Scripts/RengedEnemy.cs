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
    
    bool A1;

    public GameObject arrowstart;

    public Animator animRengeEnemy;

    public GameObject enemy;

    public NavMeshAgent ThisAgent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;


    public GameObject particle;

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
            enemy.GetComponent<Animator>().Play("Die");
            StartCoroutine(DieAnim());
        }
        HealthBar.sethealth(EnemyHealth);  

        
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }


    private void ChasePlayer()
    {
        ThisAgent.SetDestination(player.position);
        transform.LookAt(player);
    }

    private void AttackPlayer()
    {

        ThisAgent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {  
            
            //if(Canfire == false){
                enemy.GetComponent<Animator>().Play("Charge");
                if(animRengeEnemy.GetCurrentAnimatorStateInfo(0).IsName("Fire")){   
                    Rigidbody rb = Instantiate(projectile, transform.position, arrowstart.transform.rotation).GetComponent<Rigidbody>();
                    rb.AddForce(transform.forward * 100f, ForceMode.Impulse);
                    rb.AddForce(transform.up * 2f, ForceMode.Impulse);
                    
                    alreadyAttacked = true;
                    Invoke(nameof(ResetAttack), timeBetweenAttacks);
                }
        }
    }
    public void ResetAttack()
    {
        alreadyAttacked = false;
    }
    void OnTriggerEnter (Collider other){
        if(other.tag == "PlayerWeapon"){
            EnemyHealth = EnemyHealth - 1;
            GetComponent<NavMeshAgent>().speed = 0;
            StartCoroutine(ExampleCoroutine());
            HealthBar.sethealth(EnemyHealth);
            Rigidbody rb = Instantiate(particle, transform.position, transform.rotation).GetComponent<Rigidbody>();
        }
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

        IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(2);
        GetComponent<NavMeshAgent>().speed = 5 ;
    }
    IEnumerator DieAnim(){
        yield return new WaitForSeconds(1);
        PlayerUi.points = PlayerUi.points + 1; 
        Destroy(gameObject);
    }

    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}

