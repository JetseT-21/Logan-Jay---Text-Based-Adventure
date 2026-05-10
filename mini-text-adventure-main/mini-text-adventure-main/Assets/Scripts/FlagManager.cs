using UnityEngine;
using System.Collections.Generic;

public class FlagManager : MonoBehaviour
{
    private HashSet<string> _flags = new();

    public bool HasFlag(string flag)
    {
        return _flags.Contains(flag);
    }

    public void AddFlag(string flag)
    {
        if (string.IsNullOrEmpty(flag)) return;
        _flags.Add(flag);
    }
}
