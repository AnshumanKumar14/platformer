using Microsoft.Xna.Framework;
using Nez;
using Nez.Tiled;

namespace Platformer
{
    class BaseScene : Scene
    {
        public BaseScene() : base() {}

        public override void Initialize()
        {

            var map = Content.LoadTiledMap("Content/Levels/level1.tmx");
            var spawnObject = map.GetObjectGroup("objects").Objects["spawn"];
            var tiledEntity = CreateEntity("level-1");
            var tiledMapRenderer = tiledEntity.AddComponent(new TiledMapRenderer(map, "ground"));
            tiledMapRenderer.SetLayersToRender(new[] { "background", "ground", "water", "decorations" });

            var topLeft = new Vector2(map.TileWidth, map.TileWidth);
            var bottomRight = new Vector2(map.TileWidth * (map.Width - 1),
                map.TileWidth * (map.Height - 1));
            tiledEntity.AddComponent(new CameraBounds(topLeft, bottomRight));

            // create our Player and add a TiledMapMover to handle collisions with the tilemap
            var playerEntity = CreateEntity("player", new Vector2(spawnObject.X, spawnObject.Y));
            playerEntity.AddComponent(new Player());
            playerEntity.AddComponent(new BoxCollider(-8, -6, 16, 16));
            playerEntity.AddComponent(new TiledMapMover(map.GetLayer<TmxLayer>("ground")));

            Camera.Zoom = 0.04f;
            Camera.Entity.AddComponent(new FollowCamera(playerEntity));
        }
    }
}
