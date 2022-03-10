
namespace shootandRun1.Abstracts.Combats
{
    public interface IHealth
    {
        bool IsDead { get; }
        void TakeDamage(int damage);

        event System.Action OnDead;
    }
}