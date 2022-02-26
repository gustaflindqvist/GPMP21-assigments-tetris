using UnityEngine;

namespace Hud
{
    public class MiniMapCamera : MonoBehaviour
    {
        private Transform _playerTransform;
        private void Awake()
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            if(player) _playerTransform = player.transform;
        }

        private void LateUpdate()
        {
            if (!_playerTransform) return;
            var newPosition = _playerTransform.position;
            newPosition.y = transform.position.y;
            transform.position = newPosition;
            transform.rotation = Quaternion.Euler(90f, _playerTransform.eulerAngles.y, 0f);
        }
    }
}