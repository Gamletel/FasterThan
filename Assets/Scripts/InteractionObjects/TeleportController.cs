using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour
{
    [SerializeField] private GameObject _secondTeleport;
    private BoxCollider _secondTeleportCol;
    private Animator _secondTeleportAnimator;
    private Animator _animator;

    private void Start()
    {
        _secondTeleportCol = _secondTeleport.GetComponent<BoxCollider>();
        _secondTeleportAnimator = _secondTeleport.GetComponent<Animator>();
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(typeof(PlayerController), out Component component))
        {
            StartCoroutine(Teleporting(other.gameObject));
        }
    }

    private IEnumerator Teleporting(GameObject player)
    {
        _secondTeleportCol.enabled = false;
        player.transform.position = _secondTeleport.transform.position;
        _secondTeleportAnimator.SetBool("Closed", true);
        _animator.SetBool("Closed", true);
        yield return new WaitForSeconds(2f);
        _secondTeleportCol.enabled = true;
        _secondTeleportAnimator.SetBool("Closed", false);
        _animator.SetBool("Closed", false);
    }
}
