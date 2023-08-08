using CodeBase.Infrastructure;
using CodeBase.KitchenObjects;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Counters.StoveCounter
{
    public class StoveCounter : BaseCounter
    {
        private enum State
        {
            Idle = 0,
            Cooking = 1,
            Cooked = 2,
            Burned = 3
        }

        [SerializeField] private StoveCounterVisual visual;
        
        private KitchenObjectStaticData _uncookedObjectData;

        private State _state;
        private float _cookingProgress;
        private float _burningProgress;

        private bool IsFrying => _state is State.Cooking or State.Cooked;

        private void Awake() => 
            _state = State.Idle;

        private void Update()
        {
            switch (_state)
            {
                case State.Idle:
                    break;
                case State.Cooking:
                    HandleCooking();
                    break;
                case State.Cooked:
                    HandleBurning();
                    break;
                case State.Burned:
                    break;
            }
        }

        public override void Interact(IKitchenObjectParent newParent)
        {
            if (!HasKitchenObject)
            {
                if (newParent.HasKitchenObject && newParent.KitchenObject.Data.canBeCooked)
                {
                    PlaceNewKitchenObject(newParent);
                }
                else
                {
                    
                }
            }
            else
            {
                if (newParent.HasKitchenObject)
                {
                    if (newParent.KitchenObject is PlateKitchenObject plate)
                    {
                        if (plate.TryAddIngredient(KitchenObject.Data))
                        {
                            KitchenObject.DestroySelf();
                            SwitchState(State.Idle);
                        }
                    }
                    
                    if (KitchenObject is PlateKitchenObject p)
                    {
                        if (p.TryAddIngredient(newParent.KitchenObject.Data))
                            newParent.KitchenObject.DestroySelf();
                    }
                }
                else
                {
                    GivePlayerKitchenObject(newParent);
                }
            }
            // if (CanPlaceKitchenObject(newParent))
            //     PlaceNewKitchenObject(newParent);
            // else if (CanGivePlayerKitchenObject(newParent)) 
            //     GivePlayerKitchenObject(newParent);
        }

        private bool CanPlaceKitchenObject(IKitchenObjectParent newParent) => 
            !HasKitchenObject && newParent.HasKitchenObject && newParent.KitchenObject.Data.canBeCooked;

        private void PlaceNewKitchenObject(IKitchenObjectParent newParent)
        {
            ResetState();
            newParent.KitchenObject.SetParent(this);
            _uncookedObjectData = KitchenObject.Data;
        }

        private void ResetState()
        {
            _cookingProgress = 0;
            _burningProgress = 0;
            SwitchState(State.Cooking);
        }

        private bool CanGivePlayerKitchenObject(IKitchenObjectParent newParent) => 
            !newParent.HasKitchenObject && HasKitchenObject;

        private void GivePlayerKitchenObject(IKitchenObjectParent newParent)
        {
            KitchenObject.SetParent(newParent);
            SwitchState(State.Idle);
        }

        private void HandleCooking()
        {
            _cookingProgress += Time.deltaTime;
            visual.UpdateProgress(_cookingProgress, _uncookedObjectData.cookDuration);

            if (NotCookedYet())
                return;

            ReplaceKitchenObjectWith(_uncookedObjectData.cooked);
            SwitchState(State.Cooked);
        }

        private bool NotCookedYet() => 
            _cookingProgress < _uncookedObjectData.cookDuration;

        private void HandleBurning()
        {
            _burningProgress += Time.deltaTime;
            visual.UpdateProgress(_burningProgress, _uncookedObjectData.burnDuration);

            if (NotBurnedYet())
                return;

            ReplaceKitchenObjectWith(_uncookedObjectData.burned);
            SwitchState(State.Burned);
        }

        private bool NotBurnedYet() => 
            _burningProgress < _uncookedObjectData.burnDuration;

        private void ReplaceKitchenObjectWith(KitchenObjectStaticData kitchenObject)
        {
            KitchenObject.DestroySelf();
            GameFactory.CreateKitchenObject(kitchenObject, this);
        }

        private void SwitchState(State newState)
        {
            _state = newState;
            visual.Toggle(IsFrying);
        }
    }
}