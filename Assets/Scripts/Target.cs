using System.Collections;
using UnityEngine;

public class Target : MonoBehaviour
{
    MeshRenderer meshRenderer;
    Color originalColor;

    private void Start()
    {
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        originalColor = meshRenderer.material.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SeekerBullet") {
            meshRenderer.material.color = Color.red;
            StartCoroutine(WaitandReturn(5f));
            
        }
    }

    IEnumerator WaitandReturn(float seconds) {
        yield return new WaitForSeconds(seconds);
        meshRenderer.material.color = originalColor;
    }


}
