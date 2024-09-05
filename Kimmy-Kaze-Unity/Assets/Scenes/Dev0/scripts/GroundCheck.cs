using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public float rayLength = 1.1f;  // De lengte van de ray (iets langer dan de afstand van het object tot de grond)
    public LayerMask groundLayer;   // De laag van de grond (optioneel, kan gebruikt worden om specifiek te controleren op de grond)
    private bool isGrounded;        // Variabele om te controleren of het object op de grond staat

    void Update()
    {
        CheckIfGrounded();
    }

    void CheckIfGrounded()
    {
        // Raycast vanaf het midden van het object, recht naar beneden
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, rayLength, groundLayer))
        {
            isGrounded = true;
            Debug.Log("Op de grond!");
        }
        else
        {
            isGrounded = false;
            Debug.Log("Niet op de grond.");
        }
        // Debugging Ray om te zien waar de Raycast gaat
        Debug.DrawRay(transform.position, Vector3.down * rayLength, Color.red);
    }
}