using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Tiled;
using Nez.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * This function will manage the screen to show the menu options
 */
namespace Platformer
{
    class Menu : Scene
    {
        public Menu() : base()
        {
        }

        public override void Initialize()
        {
            ClearColor = Color.Black;
            var map = Content.LoadTiledMap("Content/Levels/level1.tmx");
            var spawnObject = map.GetObjectGroup("objects").Objects["spawn"];
            var tiledEntity = CreateEntity("level-1");
            var tiledMapRenderer = tiledEntity.AddComponent(new TiledMapRenderer(map, "ground"));
            tiledMapRenderer.SetLayersToRender(new[] { "background", "ground", "water", "decorations" });
            CreateEntity("menu")
                 .AddComponent<MenuItem>();
        }
    }
}
