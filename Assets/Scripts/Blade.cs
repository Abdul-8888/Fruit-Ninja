using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public GameObject bladeTrailPrefab;
    public float minVelocity = 0.001f;

    private bool isCutting = false;
    private Rigidbody2D rb;
    private Camera cam;
    private GameObject currentTrail;
    private CircleCollider2D circleCollider;
    private Vector3 previousPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        circleCollider = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartCutting();
        }

        else if(Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }

        if(isCutting)
        {
            UpdateCut();
        }
    }

    void StartCutting()
    {
        isCutting = true;
        currentTrail = Instantiate(bladeTrailPrefab, transform);
        circleCollider.enabled = true;
    }

    void UpdateCut()
    {
        Vector3 currentPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = currentPosition;

        float velocity = (currentPosition - previousPosition).magnitude * Time.deltaTime;
        previousPosition = currentPosition;

        if(velocity > minVelocity)
        {
            circleCollider.enabled = true;
        }

        else
        {
            circleCollider.enabled = false;
        }
    }

    void StopCutting()
    {
        isCutting = false;
        currentTrail.transform.SetParent(null);
        Destroy(currentTrail, 0.5f);
        circleCollider.enabled = false;
    }
}
