using UnityEngine;

public class gun : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;

    public Camera camera;
    public ParticleSystem muzzleFlash;

    public GameObject paintball;
    public Transform shotPoint;

    AudioSource paintballFireSound;


    private void Start()
    {

        paintballFireSound = this.GetComponent<AudioSource>();

    }


    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) {

            shoot();

        }
    }


    void shoot() {

        muzzleFlash.Play();
        GameObject paintballGO = Instantiate(paintball, shotPoint.position, shotPoint.rotation);
        paintballFireSound.Play();
        Destroy(paintballGO, 2f);

        RaycastHit hitInfo;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hitInfo, range)) {
           // Debug.Log(hitInfo.transform.name);

            Target target = hitInfo.transform.GetComponent<Target>();
        }

    }

}
