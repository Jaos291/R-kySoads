using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewStageConfig", menuName = "Stage Configuration", order = 51)]
public class StageConfigurationSO : ScriptableObject
{
    public float gravityScale = 1f; // Default gravity value
    public float speedMultiplier = 1f; // Default speed multiplier value
}
