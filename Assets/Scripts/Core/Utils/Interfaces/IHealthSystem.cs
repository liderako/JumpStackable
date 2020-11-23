namespace CoreGame.Utils
{
    public interface IHealthSystem
    {
        void Init(int maxHp);
        void SubstractHealth(int damage);
        void AddHealth(int amount);
        bool isDead();
    }
}