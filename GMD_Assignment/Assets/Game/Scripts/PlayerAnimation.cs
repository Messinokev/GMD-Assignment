using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    public PlayerControl _playerControl;

    private static readonly int IsRunning = Animator.StringToHash("IsRunning");

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _playerControl = new PlayerControl();
    }

    // Update is called once per frame
    void Update()
    {
        bool isLeftArrowHeld = _playerControl.Player.Movement.IsPressed();
        if (isLeftArrowHeld)
        {
            _animator.SetBool(IsRunning, true);
        }
        else
        {
            _animator.SetBool(IsRunning, false);
        }
    }
}
