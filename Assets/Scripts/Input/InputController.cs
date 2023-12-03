using System;
using System.Collections;
using UnityEngine;

namespace TankGameCore
{
    public class InputController : MonoBehaviour
    {        
        public event Action<Vector3> OnMove;
        public event Action OnFire;
        public event Action OnChooseWeaponLeft;
        public event Action OnChooseWeaponRight;

        private InputControl input;

        private Coroutine movementCoroutine;        
        private bool isMove;
        private Vector2 direction;

        private Coroutine fireCoroutine;
        private bool isFire;

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

            input.Main.Fire.performed += _ =>
            {
                if (!isFire)
                {
                    isFire = true;

                    if (fireCoroutine != null)
                        StopCoroutine(fireCoroutine);

                    fireCoroutine = StartCoroutine(FireProcess());
                }
            };

            input.Main.Fire.canceled += _ => isFire = false;

            input.Main.ChooseWeaponLeft.performed += _ => OnChooseWeaponLeft?.Invoke();
            input.Main.ChooseWeaponRight.performed += _ => OnChooseWeaponRight?.Invoke();
        }

        private IEnumerator InputMovementProcess()
        {
            while (isMove)
            {
                Vector3 movement = new Vector3(direction.x, 0f, direction.y);
                OnMove?.Invoke(movement);
                //yield return null;
                yield return new WaitForFixedUpdate();
            }

            direction = Vector2.zero;
        }

        private IEnumerator FireProcess()
        {
            while (isFire)
            {
                OnFire?.Invoke();
                yield return null;
            }
        }
    }
}