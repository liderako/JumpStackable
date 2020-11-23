namespace CoreGame.Utils
{
    public interface IAliveObject
    {
        IHealthSystem HealthSystem  {get;}
        void Death();
    }
}