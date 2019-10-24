using Nez;
using Nez.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer
{
    class Test: UICanvas
    {
/*        public override RectangleF Bounds => new RectangleF(0, 0, 200, 200);
*/        public override void Initialize()
        {
            var skin = Skin.CreateDefaultSkin();
            var table = Stage.AddElement(new Table());
            table.Defaults().SetPadTop(10).SetMinWidth(170).SetMinHeight(30);
            table.SetFillParent(true).Center();

            // add a button for each of the actions/AI types we need
            table.Add(new TextButton("Continue", skin))
                .GetElement<TextButton>()
                .OnClicked += OnClickBtLowerPriority;
            table.Row();

            table.Add(new TextButton("New game", skin))
                .GetElement<TextButton>()
                .OnClicked += LoadGame;
            table.Row();

            table.Add(new TextButton("Settings", skin))
                .GetElement<TextButton>()
                .OnClicked += OnClickBtLowerPriority;
            table.Row();

            table.Add(new TextButton("Credits", skin))
                .GetElement<TextButton>()
                .OnClicked += OnClickBtLowerPriority;
            table.Row();

            table.Add(new TextButton("Quit game", skin))
               .GetElement<TextButton>()
               .OnClicked += OnClickBtLowerPriority;
            table.Row();
        }

        void OnClickBtLowerPriority(Button butt)
        {
            //no op
        }

        void LoadGame(Button butt)
        {
            var scene = new BaseScene();
            scene.SetDesignResolution(640, 360, Scene.SceneResolutionPolicy.ShowAllPixelPerfect);
            Screen.SetSize(640 * 2, 360 * 2);
            Core.Scene = scene;
        }
    }
}
