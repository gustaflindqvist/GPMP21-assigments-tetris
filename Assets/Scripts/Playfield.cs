using UnityEngine;

// Data structure
// ___|_0_|_1_|_2_|...
// 0 | o | x | x |...
// 1 | o | x | o |...
// 2 | x | x | o |...
// ...|...|...|...|...
public class PlayField : MonoBehaviour
{
    const int Width = 10;
    const int Height = 20;

    public static Transform[,] Grid = new Transform[Width, Height];


}
