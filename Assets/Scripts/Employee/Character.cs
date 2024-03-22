using UnityEngine;

[CreateAssetMenu(fileName = "Character Data", menuName = "Scriptable Object/Character Data")]
public class Character : ScriptableObject
{
    public string Name;
    public Sprite ProfileSprite;
    public Sprite StandingSprite;
    public Grade Grade;
    public string Description;
    public int ID;
}
