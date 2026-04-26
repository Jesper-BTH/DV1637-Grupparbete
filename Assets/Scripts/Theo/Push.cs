using UnityEngine;

public class Push : MonoBehaviour
{
    public float pushStrength = 150f;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rb = hit.collider.attachedRigidbody;

        if (rb == null || rb.isKinematic)
            return;

        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        rb.AddForce(pushDir * pushStrength * Time.deltaTime, ForceMode.Impulse); // added delta time -Mattis
    }
}