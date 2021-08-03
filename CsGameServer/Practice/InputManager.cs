using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Practice
{
    class InputManager
    {
        public delegate void OnInputKey();
        //OnInputKey inputKey = new OnInputKey();
        public event OnInputKey InputKey;


        public void Update()
        {
            if (Keyboard.IsKeyDown(Key.Enter))
            {
                // 키 입력을 알린다. 
                InputKey();
            }            
        }
    }
}
