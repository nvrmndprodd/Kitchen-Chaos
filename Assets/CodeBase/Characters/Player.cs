using System;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Characters
{
    public class Player : MonoBehaviour, IKitchenObjectParent
    {
        public static Player Instance { get; private set; }
        public event EventHandler<OnSelectedCounterChangedEventArgs> OnSelectedCounterChanged;

        public class OnSelectedCounterChangedEventArgs : EventArgs
        {
            public BaseCounter selectedCounter;
        }
        
        public PlayerStaticData data;
        public PlayerAnimator animator;
        public InputHandler inputHandler;
        public Transform kitchenObjectContainer;
        public LayerMask counterLayerMask;

        private Vector3 _lastInteractDirection;
        private BaseCounter _selectedCounter;

        public Transform KitchenObjectContainer => kitchenObjectContainer;
        public KitchenObject KitchenObject { get; private set; }
        public bool HasKitchenObject => KitchenObject != null;

        private void Awake()
        {
            if (Instance != null)
                Destroy(gameObject);

            Instance = this;
        }

        private void Start()
        {
            inputHandler.OnInteractAction += OnInteract;
        }

        private void OnInteract(object sender, EventArgs e)
        {
            if (_selectedCounter != null) 
                _selectedCounter.Interact(this);
        }

        private void Update()
        {
            HandleMovement();
            HandleInteractions();
        }

        private void HandleMovement()
        {
            var direction = GetMoveDirection();
            var acceleration = Time.deltaTime * data.speed;
            var canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * data.playerHeight,
                data.playerRadius, direction, acceleration);

            if (IsNotMoving(direction))
            {
                animator.StopMoving();
                return;
            }

            if (!canMove)
            {
                var directionX = new Vector3(direction.x, 0, 0).normalized;
                var canMoveX = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * data.playerHeight,
                    data.playerRadius, directionX, acceleration);

                if (canMoveX)
                    direction = directionX;
                else
                {
                    var directionZ = new Vector3(0, 0, direction.z).normalized;
                    var canMoveZ = !Physics.CapsuleCast(transform.position,
                        transform.position + Vector3.up * data.playerHeight, data.playerRadius, directionZ,
                        acceleration);

                    if (canMoveZ)
                        direction = directionZ;
                    else
                        return;
                }
            }

            transform.position += direction * acceleration;
            transform.forward = Vector3.Slerp(transform.forward, direction, Time.deltaTime * data.rotationSpeed);
            animator.StartMoving();
        }

        private void HandleInteractions()
        {
            var direction = GetMoveDirectionOrLastInteractDirection();
            const float interactDistance = 2f;
            if (Physics.Raycast(transform.position, direction, out var hit, interactDistance, counterLayerMask))
            {
                if (hit.transform.TryGetComponent<BaseCounter>(out var clearCounter))
                {
                    if (clearCounter == _selectedCounter) 
                        return;

                    UpdateSelectedCounter(clearCounter);
                }
                else
                {
                    UpdateSelectedCounter(null);
                }
            }
            else
            {
                UpdateSelectedCounter(null);
            }
        }

        private Vector3 GetMoveDirection()
        {
            var inputVector = inputHandler.GetMovementVectorNormalized();
            var direction = new Vector3(inputVector.x, 0f, inputVector.y);
            
            UpdateLastInteractDirection(direction);
            
            return direction;
        }

        private Vector3 GetMoveDirectionOrLastInteractDirection()
        {
            var inputVector = inputHandler.GetMovementVectorNormalized();
            var direction = new Vector3(inputVector.x, 0f, inputVector.y);

            return !IsNotMoving(direction) 
                ? direction 
                : _lastInteractDirection;
        }

        private void UpdateLastInteractDirection(Vector3 direction)
        {
            if (!IsNotMoving(direction))
                _lastInteractDirection = direction;
        }

        private static bool IsNotMoving(Vector3 direction) => 
            direction.sqrMagnitude <= float.Epsilon;

        private void UpdateSelectedCounter(BaseCounter counter)
        {
            _selectedCounter = counter;
            OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs()
            {
                selectedCounter = _selectedCounter
            });
        }

        public void SetKitchenObject(KitchenObject kitchenObject) => 
            KitchenObject = kitchenObject;

        public void ClearKitchenObject() => 
            KitchenObject = null;
    }
}