using Nez;
using Nez.Tweens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer
{
    class StateManager
    {
        public void SetState(StateType state, bool transition = false)
        {
            SetScene(SceneFactory.CreateScene(state), transition);
        }

        private void SetScene(Scene scene, bool transition)
        {
            scene.SetDesignResolution(Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT, Scene.SceneResolutionPolicy.ShowAllPixelPerfect);
            if (transition)
            {
                TweenManager.StopAllTweens();
                Game.StartSceneTransition(new CrossFadeTransition(() => scene));
            }
            else
            {
                Game.Scene = scene;
            }

        }
    }
}
