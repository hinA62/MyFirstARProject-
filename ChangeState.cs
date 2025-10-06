using UnityEngine;

public class ChangeState : MonoBehaviour
{
    public Collider collider1;
    public Collider collider2;
    public Animator animator1;
    public Animator animator2;

    public float attackRange = 0.03f;

    void Update()
    {
        if (collider1 == null || collider2 == null) return;

        float distanceBetweenEdges = GetEdgeDistance(collider1, collider2);
        bool shouldAttack = distanceBetweenEdges <= attackRange;

        Debug.Log($"Distnce: {distanceBetweenEdges:F3} | shouldAttack = {shouldAttack}");

        if (animator1 != null)
            animator1.SetBool("is_attacking", shouldAttack);
        if (animator2 != null)
            animator2.SetBool("is_attacking", shouldAttack);
    }

    private float GetEdgeDistance(Collider collider1, Collider collider2)
    {
        float centerDistance = Vector3.Distance(collider1.bounds.center, collider2.bounds.center);

        float radius1 = collider1.bounds.extents.magnitude;
        float radius2 = collider2.bounds.extents.magnitude;

        float edgeDistance = centerDistance - (radius1 + radius2);

        return Mathf.Max(0f, edgeDistance);
    }
}
