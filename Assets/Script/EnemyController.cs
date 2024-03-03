using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Animator animator;
    [SerializeField] private float time = 3f;
    private float lastTime;
    private bool onPath = false;
    public event Action hit;
    // Start is called before the first frame update
    void Start()
    {
        SetDestination();
    }

    private void SetDestination()
    {
        if (RandomPoint(out Vector3 result))
        {
            navMeshAgent.SetDestination(result);
            onPath = true;
        }
    }

    public float range = 100.0f;

    bool RandomPoint(out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint =  UnityEngine.Random.insideUnitSphere * range;
            NavMeshHit hit;

            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
            Debug.Log("Destination" + result);

                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }

    protected bool pathComplete()
	{
        NavMeshAgent agent = navMeshAgent;
        float dist=agent.remainingDistance;
		if (dist!=Mathf.Infinity && agent.pathStatus==NavMeshPathStatus.PathComplete && agent.remainingDistance==0)
            return true;
		return false;
	}
   void OnCollisionEnter(Collision collision){
        if(collision.transform.CompareTag("Bullet")){
            hit?.Invoke();
              animator.Play("Appear", -1, 0f);
            SetDestination();
            onPath = true;
        }
   }

   void Update(){
    
    if(onPath){
        if(pathComplete()){
            onPath = false;
            lastTime = Time.timeSinceLevelLoad;
            animator.Play("Disapear", -1, 0f);
        }
    }
    else
        CheckIfDeactiveForAWhile();

   }

    private void CheckIfDeactiveForAWhile()
    {
        if(Time.timeSinceLevelLoad - lastTime > time){
            animator.Play("Disapear", -1, 0f);
            lastTime = Time.timeSinceLevelLoad;
        }
    }
}
