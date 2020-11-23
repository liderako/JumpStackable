namespace CoreGame.Utils
{
    public interface IDamagable
    {
        void ReceiveHit(int damage);
        int GetHp();
    }
}