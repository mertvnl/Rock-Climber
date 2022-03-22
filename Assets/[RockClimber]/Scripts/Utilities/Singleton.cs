using UnityEngine;

/// <summary>
/// Singleton only let one instace of Type T per scene.
/// <para>Note: Singleton instance can be destroyed.</para>
/// </summary>
/// <typeparam name="T">T inherits from $$anonymous$$onoBehavior</typeparam>
public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<T>();
            if (instance == null)
                Debug.LogError("Singleton<" + typeof(T) + "> instance has been not found.");
            return instance;
        }
    }

    protected void Awake()
    {
        if (this.GetType() != typeof(T))
            DestroySelf();

        if (instance == null)
            instance = this as T;
        else if (instance != this)
            DestroySelf();
    }

    protected void OnValidate()
    {
        if (this.GetType() != typeof(T)) //Change to solve the problem
        {
            Debug.LogError("Singleton<" + typeof(T) + "> has a wrong Type Parameter. " +
                "Try Singleton<" + this.GetType() + "> ins$$anonymous$$d.");
#if UNITY_EDITOR
                         UnityEditor.EditorApplication.delayCall -= DestroySelf;
                         UnityEditor.EditorApplication.delayCall += DestroySelf;
#endif
        }

        if (instance == null)
            instance = this as T;
        else if (instance != this)
        {
            Debug.LogError("Singleton<" + this.GetType() + "> already has an instance on scene. Component will be destroyed.");
#if UNITY_EDITOR
             UnityEditor.EditorApplication.delayCall -= DestroySelf;
             UnityEditor.EditorApplication.delayCall += DestroySelf;
#endif
        }
    }


    private void DestroySelf()
    {
        if (Application.isPlaying)
            Destroy(this);
        else
            DestroyImmediate(this);
    }
}