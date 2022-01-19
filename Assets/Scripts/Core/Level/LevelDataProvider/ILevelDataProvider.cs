using System.Collections.Generic;

public interface ILevelDataProvider
{
    IReadOnlyList<LevelData> LevelData { get; }
}