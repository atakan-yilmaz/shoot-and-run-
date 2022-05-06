using shootandRun1.ScriptableObjects;


namespace shootandRun1.Abstracts.Combats
{
    public interface IAttackType
    {
        void AttackAction();

        public AttackSO AttackInfo { get; }
    }
}