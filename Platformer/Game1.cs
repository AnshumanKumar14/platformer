﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;

namespace Platformer
{
    public class Game1 : Core
    {
        public Game1()
        {
            IsFixedTimeStep = false;
        }

        protected override void Initialize()
        {
            base.Initialize();
            var scene = new Menu();
            scene.SetDesignResolution(640, 360, Scene.SceneResolutionPolicy.ShowAllPixelPerfect);
            Screen.SetSize(640 * 2, 360 * 2);
            Scene = scene;
        }
    }
}
