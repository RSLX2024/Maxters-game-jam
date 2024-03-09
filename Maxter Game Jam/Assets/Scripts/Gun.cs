using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float maxReload; 
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shotPoint; 
    public float offset;

    private float reload;
    private Vector3 difference;
    private float rotZ;

    private void Update()
    {
        difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if(Input.GetMouseButton(0))
        {
            if(reload <= 0)
            {
                reload = maxReload;
                Instantiate(bullet, shotPoint.position, shotPoint.rotation);
            }
        }

        if(reload > 0)
        {
            reload -= Time.deltaTime;
        }
    }


}
