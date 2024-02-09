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
        SpawnVFX(spawnVFX);
    }

    private void ApplyRandomForce() {
        float yForce = Random.Range(minYForce, maxYForce);
        float xForce = Random.Range(minXForce, maxXForce);

        Vector2 motion = new Vector2(xForce, yForce);

        myBody.AddForce(motion, ForceMode2D.Impulse);
        myBody.angularVelocity = Random.Range(-360f, 360f);
    }


    public void Collect() {
        SpawnVFX(collectVFX);
        HudPanel.UpdateScoreText(points);
        Destroy(gameObject);
    }

    public void ForceDie() {
        SpawnVFX(spawnVFX);
        Destroy(gameObject);
    }


    private void SpawnVFX(GameObject prefab) {
        if (prefab == null)
            return;

        GameObject activeVFX = Instantiate(prefab, transform.position, Quaternion.identity);
        Destroy(activeVFX, 1f);
    }
}
