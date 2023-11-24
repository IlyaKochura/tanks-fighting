using System;
using System.Collections.Generic;
using System.Linq;
using Code.Shooting.Enums;
using UnityEngine;

namespace Code.Shooting
{
    public class WeaponsViewsContainer : MonoBehaviour
    {
        [SerializeField] private List<WeaponView> _weaponViews;

        public void DisableAll()
        {
            _weaponViews.ForEach(view => view.SetActive(false));
        }

        public void EnableWeaponView(WeaponsViewVariants viewVariant)
        {
            var weaponView = _weaponViews.FirstOrDefault(view => viewVariant == view.WeaponViewVariantVariant);

            if (weaponView == default)
            {
                Debug.LogError($"Not found view for {viewVariant.ToString()}");
                return;
            }
            
            weaponView.SetActive(true);
        }
    }
}