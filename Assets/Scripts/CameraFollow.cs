using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private BirdController _birdController;
    private void Update()
    {
        if(_birdController.isStart)
        {
            Vector3 targetPosition = new Vector3(0f, _player.position.y + 4f, transform.position.z); 

            transform.position = Vector3.Lerp(transform.position, targetPosition, 3f*Time.deltaTime);            
        }
    }
}
