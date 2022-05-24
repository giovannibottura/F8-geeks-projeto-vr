using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    public EnemyHealthBar HealthBar;
    public Player Player;
    public GameObject enemy;
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    public int EnemyHealth;
    public int MaxEnemyHealth;
    public Animator animEnemy;
    
    // Attacking

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
    }

    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRenge, whatIsPlayer);
        
        if(playerInSightRange && !playerInAttackRange) ChasePlayer();
        if(playerInSightRange && playerInAttackRange) AttackPlayer();
        
        if(Player.AninDefend == false){
            animEnemy.SetBool("V1", false);
        }
        else if(Player.AninDefend == true){
            animEnemy.SetBool("V1", true);
        }
        if(EnemyHealth == 0){
            Destroy(gameObject);
        }
        HealthBar.sethealth(EnemyHealth);
    }

    
    private void Awake(){
        player = GameObject.Find("OVRPlayerController").transform;
        agent = GetComponent<NavMeshAgent>();

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
            
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    
    private void ResetAttack(){
        enemy.GetComponent<Animator>().Play("enemy idle");
        alreadyAttacked = false;
        
    }
    void OnTriggerEnter (Collider other){
        if(other.tag == "PlayerWeapon"){
            Invoke(nameof(TakeDamege), 0.5f);
        }
    }
    public void TakeDamege(int damage){
        
        EnemyHealth = EnemyHealth - 1;
        HealthBar.sethealth(EnemyHealth);
    }




}

