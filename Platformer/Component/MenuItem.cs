using Nez;
using Nez.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer
{
    class MenuItem: UICanvas
    {
/*        public override RectangleF Bounds => new RectangleF(0, 0, 200, 200);
*/        public override void Initialize()
        {
            var skin = Skin.CreateDefaultSkin();
            var table = Stage.AddElement(new Table());
            table.Defaults().SetPadTop(10).SetMinWidth(170).SetMinHeight(30);
            table.SetFillParent(true).Center();

            // add a button for each of the actions/AI types we need
            table.Add(new TextButton(Constants.MENU_PLAY, skin))
                .GetElement<TextButton>()
                .OnClicked += LoadGame;
            table.Row();

            table.Add(new TextButton(Constants.MENU_OPTION, skin))
                .GetElement<TextButton>()
                .OnClicked += OnClickBtLowerPriority;
            table.Row();

            table.Add(new TextButton(Constants.MENU_CREDITS, skin))
                .GetElement<TextButton>()
                .OnClicked += OnClickBtLowerPriority;
            table.Row();

            table.Add(new TextButton(Constants.MENU_EXIT, skin))
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
            Game.ManagerState.SetState(StateType.LoadLevel, true);
        }
    }
}
