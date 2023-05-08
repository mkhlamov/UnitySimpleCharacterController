using ITB.Common;
using UnityEngine;
using Zenject;

namespace ITB.Player
{
    public class PlayerShooting : MonoBehaviour
    {
        [SerializeField] private Weapon.Weapon primaryWeapon;
        [SerializeField] private Weapon.Weapon secondaryWeapon;

        private GameInput gameInput;

        [Inject]
        public void Construct(GameInput gameInput)
        {
            this.gameInput = gameInput;
        }

        private void OnEnable()
        {
            gameInput.OnPrimaryShoot += OnPrimaryWeaponFired;
            gameInput.OnSecondaryShoot += OnSecondaryWeaponFired;
        }

        private void OnDisable()
        {
            gameInput.OnPrimaryShoot -= OnPrimaryWeaponFired;
            gameInput.OnSecondaryShoot -= OnSecondaryWeaponFired;
        }

        public void ApplyDamageMultiplier(float damageMultiplier)
        {
            if (primaryWeapon != null)
            {
                primaryWeapon.ApplyDamageMultiplier(damageMultiplier);
            }
            
            if (secondaryWeapon != null)
            {
                secondaryWeapon.ApplyDamageMultiplier(damageMultiplier);
            }
        }

        private void OnPrimaryWeaponFired()
        {
            if (primaryWeapon != null)
            {
                primaryWeapon.Shoot();
            }
            else
            {
                Debug.LogError($"Primary weapon isn't set!");
            }
        }

        private void OnSecondaryWeaponFired()
        {
            if (secondaryWeapon != null)
            {
                secondaryWeapon.Shoot();
            } else
            {
                Debug.LogError($"Secondary weapon isn't set!");
            }
        }
    }
}