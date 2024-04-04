using System;
using Microsoft.Xna.Framework;

public static class Camera{
    public static void Update(Point playerOffset, GameObject[] gameObjects, GameObject portal){
        foreach (GameObject item in gameObjects)
        {
            item.Position = item.Position - playerOffset;
        }

        portal.Position = portal.Position - playerOffset;
    }
}
