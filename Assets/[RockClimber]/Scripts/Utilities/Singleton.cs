using UnityEngine;

/// <summary>
/// Singleton only let one instace of Type T per scene.
/// <para>Note: Singleton instance can be destroyed.</para>
/// </summary>
/// <typeparam name="T">T inherits from MonoBehavior</typeparam>
public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<T>();
            return instance;
        }
    }
}