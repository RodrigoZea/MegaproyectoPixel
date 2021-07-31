public interface IState
{
    // Start is called before the first frame update
    void Tick();
    void OnEnter();
    void OnExit();
}
