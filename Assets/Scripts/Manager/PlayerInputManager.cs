using System;

namespace SomeAnyBird.Manager
{
    public static class PlayerInputManager
    {
        public static event Action OnJump;

        public static void Jump()
        {
            OnJump?.Invoke();
        }
        
    }
}