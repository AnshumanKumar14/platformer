using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;

namespace Platformer
{
    public class Game : Core
    {
        private static StateManager managerState;
        private static StateType currentScene;
        public Game(): base(windowTitle: Constants.GAME_TITLE)
        {
            IsFixedTimeStep = false;
            ManagerState = new StateManager();
        }

        internal static StateManager ManagerState { get => managerState; set => managerState = value; }
        internal static StateType CurrentScene { get => currentScene; set => currentScene = value; }

        protected override void Initialize()
        {
            base.Initialize();
            Screen.SetSize(640 * 2, 360 * 2);
            ManagerState.SetState(StateType.MainMenu);
            CurrentScene = StateType.MainMenu;
        }
    }
}
