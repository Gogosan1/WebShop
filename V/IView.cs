using System;

namespace WebShop.V
{
    public interface IView
    {
        public event EventHandler<SignInOrUpEventArgs> SignUpButtonClickHandler;
        public event EventHandler<FogotPasswordEventArgs> FogotPasswordButtonClickHandler;
        public event EventHandler<SignInOrUpEventArgs> SignInButtonClickHandler;
    }
}
