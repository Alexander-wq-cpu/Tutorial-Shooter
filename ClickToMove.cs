using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    private NavMeshAgent navAgent;

    private void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            //¬ыпускаем луч из курсора мыши .  урсор приклеен к центру экрана
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //провер€ем столкнулс€ ли луч с землей
            if (Physics.Raycast(ray, out hit,Mathf.Infinity,NavMesh.AllAreas))
            {
                //двигаем зомби к точке столкновени€ луча с землей
                navAgent.SetDestination(hit.point);
            }
        }
    }

    /*private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //выпускаем луч из центра экрана
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            NavMeshHit navHit;
            //получаем точку начала луча и направление
            Vector3 start = ray.origin;
            Vector3 direction = ray.direction;
            //устанавливаем длину луча
            float maxDistance = 1000f;

            //берем 2 точки : начало(start) и конец луча(start + direction * maxDistance)
            //провер€ем есть ли между этими точками NavMesh объект , земл€ в данном случае
            if (NavMesh.Raycast(start, start + direction * maxDistance, out navHit, NavMesh.AllAreas))
            {
                //двигаем зомби к точке столкновени€ луча с землей
                navAgent.SetDestination(navHit.position);
            }
        }
    }*/
}

