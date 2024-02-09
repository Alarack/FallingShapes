using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleObject : MonoBehaviour
{
    [Header("Score Variables")]
    public float points;

    [Header("Falling Variables")]
    public float maxYForce;
    public float minYForce;
    public float maxXForce;
    public float minXForce;

    [Header("VFX")]
    public GameObject spawnVFX;
    public GameObject collectVFX;




    private Rigidbody2D myBody;


    private void Awake() {
        myBody = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        ApplyRandomForce();
        SpawnVFX();
    }

    private void ApplyRandomForce() {
        float yForce = Random.Range(minYForce, maxYForce);
        float xForce = Random.Range(minXForce, maxXForce);

        Vector2 motion = new Vector2(xForce, yForce);


        myBody.AddForce(motion, ForceMode2D.Impulse);
        myBody.angularVelocity = Random.Range(-360f, 360f);
    }


    public void Collect() {
        SpawnCollectionVFX();
        HudPanel.UpdateScoreText(points);
        Destroy(gameObject);
    }

    public void ForceDie() {
        SpawnVFX();
        Destroy(gameObject);
    }

    private void SpawnCollectionVFX() {
        if (collectVFX == null)
            return;

        GameObject activeVFX = Instantiate(collectVFX, transform.position, Quaternion.identity);
        Destroy(activeVFX, 1f);
    }

    private void SpawnVFX() {
        if (spawnVFX == null)
            return;

        GameObject activeVFX = Instantiate(spawnVFX, transform.position, transform.rotation);
        Destroy(activeVFX, 1f);
    }
}
