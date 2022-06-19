public class PlayerStatus
{
    public int HP { get; private set; }
    public int MP { get; private set; }
    public bool IsPoison { get; private set; }

    public PlayerStatus(int hp, int mp, bool isPoison)
    {
        HP = hp;
        MP = mp;
        IsPoison = isPoison;
    }
}
