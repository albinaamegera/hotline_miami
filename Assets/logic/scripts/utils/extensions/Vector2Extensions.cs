using UnityEngine;

public static class Vector2Extensions
{
    public static Vector2 ToWorldPoints(this Vector2 vector2)
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        float x = vector2.x - screenWidth / 2;
        float y = vector2.y - screenHeight / 2;
        return new Vector2(x, y);
    }
}
