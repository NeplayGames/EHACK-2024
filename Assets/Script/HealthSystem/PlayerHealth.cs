using System;
using System.Runtime.CompilerServices;

public class PlayerHealth{


    private int health;
    public event Action Died;
    public int Health{
        get {
            return health;
        }
        set {
            health = value;
        }
    }

    private int maxHealth = 2;

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