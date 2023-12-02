using System;
using System.Collections;
using UnityEngine;

namespace TankGameCore
{
    public class InputController : MonoBehaviour
    {
        public event Action<Vector3> OnMove;

        private InputControl input;
        private Coroutine movementCoroutine;
        private bool isMove;
        private Vector2 direction;

        private void Awake() => input = new InputControl();

        private void OnEnable() => input.Enable();

        private void OnDisable() => input.Disable();

        private void Start()
        {
            input.Main.Movement.performed += context =>
            {
                direction = context.ReadValue<Vector2>();

                if (!isMove)
                {
                    isMove = true;
                    
                    if (movementCoroutine != null)
                        StopCoroutine(movementCoroutine);
                    
                    movementCoroutine = StartCoroutine(InputMovementProcess());
                }
            };

            input.Main.Movement.canceled += _ => isMove = false;
        }

        private IEnumerator InputMovementProcess()
        {
            while (isMove)
            {
                Vector3 movement = new Vector3(direction.x, 0f, direction.y);
                OnMove?.Invoke(movement);
                yield return null;
            }

            direction = Vector2.zero;
        }
    }
}