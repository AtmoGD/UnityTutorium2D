using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class InputController : MonoBehaviour
{
    private CharacterController character;

    void Awake()
    {
        character = GetComponent<CharacterController>();
    }

    public void OnMove(InputAction.CallbackContext _context)
    {
        if(!character) return;

        character.ChangeMovementDirection(_context.ReadValue<Vector2>());
    }

    public void OnDash(InputAction.CallbackContext _context)
    {
        if(!character) return;
        
        if (_context.phase == InputActionPhase.Started)
            character.Dash();
    }

    public void OnFireball(InputAction.CallbackContext _context)
    {
        if(!character) return;

        if (_context.phase == InputActionPhase.Started)
            character.Fireball();
    }

    public void OnInteract(InputAction.CallbackContext _context)
    {
        if(!character) return;

        if (_context.phase == InputActionPhase.Started)
            character.Interact();
    }
}
