namespace Interfaces
{
    public interface ICharacter
    {
        bool IsAlive { get;  }
        float Health { get; set;  }
        bool IsEnemy { get; set; }
    }
}
