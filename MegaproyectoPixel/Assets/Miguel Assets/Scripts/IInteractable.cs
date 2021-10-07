
public interface IInteractable 
{
    string key {get;}
    bool locked {get;}

    void OnInteract(string requisite);


}
