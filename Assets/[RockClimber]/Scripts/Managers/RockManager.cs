using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine; 

public class RockManager : Singleton<RockManager>
{
    private List<JumpableRock> rocks = new List<JumpableRock>();

    private void OnEnable()
    {
        LevelManager.Instance.OnLevelFinish.AddListener(ClearRockList);
    }

    private void OnDisable()
    {
        LevelManager.Instance.OnLevelFinish.RemoveListener(ClearRockList);
    }

    public void AddRock(JumpableRock rock)
    {
        if (rocks.Contains(rock))
            return;

        rocks.Add(rock);

        UpdateRocks();
    }

    private void UpdateRocks()
    {
        rocks = rocks.OrderBy(go => go.transform.position.y).ToList();

        for (int i = 0; i < rocks.Count; i++)
        {
            rocks[i].UpdateColor();
        }

        rocks[rocks.Count - 1].UpdateColor(true);
    }

    // Limit player to jump one by one
    public bool CheckIfCanJump(JumpableRock targetRock, JumpableRock currentRock)
    {
        if (Mathf.Abs(rocks.IndexOf(targetRock) - rocks.IndexOf(currentRock)) > 1)
            return false;
        else
            return true;
    }

    public JumpableRock GetLastRock()
    {
        return rocks.Count > 0 ? rocks[rocks.Count - 1] : null;
    }

    public JumpableRock GetStartingRock()
    {
        return rocks.Count > 0 ? rocks[0] : null;
    }

    private void ClearRockList()
    {
        rocks.Clear();
    }
}
