using Code.DamageAndHealth.Contracts;
using Code.Plugins.com.supremestranger.leoecs_lite_physics.Runtime.Contracts;
using Code.Shooting.Contracts;
using LeoEcsPhysics;

namespace Code.DamageAndHealth
{
    public class Damageable : BasePhysicsChecker, IDamageable
    {
        public void ApplyDamage(float damage)
        {
            EcsPhysicsEvents.RegisterDamageEvent(entity, damage);
        }
    }
}