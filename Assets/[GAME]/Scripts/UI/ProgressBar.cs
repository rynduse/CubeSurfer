using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Transform startTransform;
    [SerializeField] private Transform goalTransform;
    [SerializeField] private Transform Player;
    [SerializeField] private Image fillBarProgress;
    private float lastValue;

    public float EntireDistance { get; private set; }
    public float DistanceLeft { get; private set; }


    private void Start()
    {
        EntireDistance = goalTransform.position.z - startTransform.position.z;
    }

    void Update()
    {
        DistanceLeft = Vector3.Distance(Player.transform.position, goalTransform.position);
        if (DistanceLeft > EntireDistance)
        {
            DistanceLeft = EntireDistance;
        }
        if (Player.transform.position.z > goalTransform.transform.position.z)
        {
            DistanceLeft = 0;
        }

        float traveledDistance = EntireDistance - DistanceLeft;
        float value = traveledDistance / EntireDistance;
        fillBarProgress.fillAmount = Mathf.Lerp(fillBarProgress.fillAmount, value, 5 * Time.deltaTime);
        lastValue = value;
    }
}
