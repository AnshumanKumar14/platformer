using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;

namespace Platformer
{
    class SceneFactory
    {
        public static Scene CreateScene(StateType type)
        {
            switch(type)
            {
                case StateType.LoadLevel:
                    return new BaseScene();
                default:
                    return new Menu();
            }
        }
    }
}
