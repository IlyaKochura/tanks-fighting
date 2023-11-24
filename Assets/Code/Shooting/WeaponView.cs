using Code.Shooting.Enums;
using UnityEngine;

namespace Code.Shooting
{
    public class WeaponView : MonoBehaviour
    {
        [SerializeField] private WeaponsViewVariants weaponsViewVariant;

        public WeaponsViewVariants WeaponViewVariantVariant => weaponsViewVariant;

        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}
