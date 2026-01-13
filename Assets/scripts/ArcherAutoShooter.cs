using UnityEngine;
using System.Collections;

public class ArcherAutoShooter : MonoBehaviour
{
    [Header("References")]
    public Transform anchorPoint;      // point de tir (dans la tour)
    public Transform target;           // ta mascotte / XR Rig
    public GameObject arrowPrefab;     // prefab qui a HumanArcherArrow

    [Header("Fire settings")]
    //public float fireRate = 1.0f;      // 1 = 1 flèche / seconde
    public float minInterval = 1f;
    public float maxInterval = 2.5f;
    public Vector3 aimOffset;          // optionnel: viser un peu au-dessus (tête)



    //pour la deviation
    [Header("Aim deviation (spread)")]
    [Tooltip("Max deviation angle in degrees.")]
    public float maxDeviationDegrees = 8f;

    [Tooltip("Chance (0..1) that a shot will deviate at all.")]
    [Range(0f, 1f)] public float deviationChance = 0.6f;


    private Coroutine loop;

    void OnEnable()
    {
        loop = StartCoroutine(ShootLoop());
    }

    void OnDisable()
    {
        if (loop != null) StopCoroutine(loop);
    }

    IEnumerator ShootLoop()
    {
        while (true)
        {
            Shoot();
            float randomWaitTime = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(randomWaitTime);
        }
    }

    void Shoot()
    {
        if (!anchorPoint || !target || !arrowPrefab) return;

        Vector3 targetPos = target.position + aimOffset;
        Vector3 dir = (targetPos - anchorPoint.position).normalized;

    // Random deviation
        if (Random.value < deviationChance && maxDeviationDegrees > 0f)
        {
            // pick random yaw/pitch angles (random amount, random direction)
            float yaw = Random.Range(-maxDeviationDegrees, maxDeviationDegrees);
            float pitch = Random.Range(-maxDeviationDegrees, maxDeviationDegrees);

            // rotate direction in world space
            Quaternion spreadRot = Quaternion.AngleAxis(yaw, Vector3.up) * Quaternion.AngleAxis(pitch, Vector3.right);
            dir = (spreadRot * dir).normalized;
        }



        // Rotation : le forward (+Z) de la flèche pointe vers la cible
        Quaternion rot = Quaternion.LookRotation(dir, Vector3.up);

        Instantiate(arrowPrefab, anchorPoint.position, rot);
    }
}
