using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class FarmerEnemy : MonoBehaviour
{
 
    

    AudioSource AtackSound;

    public GameObject particle;

    public HealthBarScrip PlayerUi;
    public EnemyHealthBar HealthBar;
    public Player playerSC;
   
    public GameObject enemy;
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public int EnemyHealth;
    public int MaxEnemyHealth;
    public Animator animEnemy;
    public CapsuleCollider EnemyCollider;
    // Attacking

    CapsuleCollider collider; 

    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public float sightRange;
    public float attackRenge;
    public bool playerInSightRange, playerInAttackRange;

    void Start()
    {
              


        collider = GetComponent<CapsuleCollider>();
        AtackSound = GetComponent<AudioSource>();
       
        HealthBar.setmaxhealth(MaxEnemyHealth);
       
        EnemyHealth = MaxEnemyHealth;
        enemy.GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(alreadyAttacked == true){
              enemy.transform.Rotate(0, 0, 0);
        }

        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRenge, whatIsPlayer);
        player = GameObject.Find("OvrGameOBJ").transform;
            
        if(playerInSightRange && !playerInAttackRange) ChasePlayer();
        if(playerInSightRange && playerInAttackRange) AttackPlayer();
    }


    private void Awake(){
        
        agent = GetComponent<NavMeshAgent>();

    }
    
    
    private void ChasePlayer(){
        agent.SetDestination(player.position);
        transform.LookAt(player);
        print("as");
    }
    
    
    private void AttackPlayer(){
        agent.SetDestination(transform.position);
        transform.LookAt(player, new Vector3(0, 1, 0));
        
        if (!alreadyAttacked){
            agent.SetDestination(transform.position);
            enemy.GetComponent<Animator>().Play("FarmerAtack");
           // AtackSound.Play(0);
            alreadyAttacked = true;
         //   animEnemy.SetBool("V1", false);
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
      

    private void ResetAttack(){
        enemy.GetComponent<Animator>().Play("AngryIdle");
        alreadyAttacked = false;
        
    }

    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRenge);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
































}
