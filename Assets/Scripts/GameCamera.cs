using System;
using Gustaf.Scripts.Managers;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float maxDistance;

    // private void FixedUpdate()
    // {
    //     if (!GameManager.Instance.Player) return;
    //     var cameraPosition = transform.position;
    //     var position = GameManager.Instance.Player.transform.position;
    //     var distance = (cameraPosition - position).magnitude;
    //     // Min move speed, max move speed
    //     var speed = Mathf.Lerp(minSpeed, maxSpeed, distance / maxDistance);
    //     cameraPosition = Vector3.MoveTowards(cameraPosition, position, speed * Time.fixedDeltaTime);
    //     transform.position = cameraPosition;
    // }
}
