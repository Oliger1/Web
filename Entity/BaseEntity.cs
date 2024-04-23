namespace WebOliger.Entity

{ 
public abstract class BaseEntity
{
}

public abstract class BaseEntityWithKey<TKey> : BaseEntity
{
    public TKey Id { get; set; }
}
    public abstract class BaseEntityWithKey : BaseEntityWithKey<int>
    {
    }

}