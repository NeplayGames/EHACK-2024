using System;
using System.Runtime.CompilerServices;

public class PlayerHealth{


    private int health;
    public event Action Died;
    public event Action<int , int> HealthChange;
    public int Health{
        get {
            return health;
        }
        set {
            HealthChange?.Invoke(value, maxHealth);
            health = value;
        }
    }

    private int maxHealth = 20;

    public PlayerHealth()
    {
        Health = maxHealth;
    }

    public void RemoveHealth(int health){
        this.Health -= health;
        if(Health <= 0)
        Died?.Invoke();
    }
}