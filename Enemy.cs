using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int HP = 100;
    private Animator animator;
    private NavMeshAgent navAgent;

    public bool isDead;
    private void Start()
    {
        animator = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
    }

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;

        if(HP <= 0)
        {
            int randomValue = Random.Range(0, 2);

            if(randomValue == 0)
            {
                animator.SetTrigger("DIE1");
            }
            else
            {
                animator.SetTrigger("DIE2");
            }

            isDead = true;

            // DEAD sound
            SoundManager.Instance.zombieChannel.PlayOneShot(SoundManager.Instance.zombieDeath);
        }
        else
        {
            animator.SetTrigger("DAMAGE");

            // HURT sound
            SoundManager.Instance.zombieChannel2.PlayOneShot(SoundManager.Instance.zombieHurt);
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 2.5f); //attack area

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 100f); //detection area

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 101f); // stop chasing area
    }
}
