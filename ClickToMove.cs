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
            //��������� ��� �� ������� ���� . ������ �������� � ������ ������
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //��������� ���������� �� ��� � ������
            if (Physics.Raycast(ray, out hit,Mathf.Infinity,NavMesh.AllAreas))
            {
                //������� ����� � ����� ������������ ���� � ������
                navAgent.SetDestination(hit.point);
            }
        }
    }

    /*private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //��������� ��� �� ������ ������
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            NavMeshHit navHit;
            //�������� ����� ������ ���� � �����������
            Vector3 start = ray.origin;
            Vector3 direction = ray.direction;
            //������������� ����� ����
            float maxDistance = 1000f;

            //����� 2 ����� : ������(start) � ����� ����(start + direction * maxDistance)
            //��������� ���� �� ����� ����� ������� NavMesh ������ , ����� � ������ ������
            if (NavMesh.Raycast(start, start + direction * maxDistance, out navHit, NavMesh.AllAreas))
            {
                //������� ����� � ����� ������������ ���� � ������
                navAgent.SetDestination(navHit.position);
            }
        }
    }*/
}

