using Kaazing.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoDemo
{
    public class LoginHandlerDemo : LoginHandler
    {
        private MainPage parent;
        /// <summary>
        /// constructor
        /// <para>pass in main form for callback</para>
        /// </summary>
        /// <param name="form"></param>
        public LoginHandlerDemo(MainPage form)
        {
            this.parent = form;
        }


        #region LoginHandler Members

        PasswordAuthentication LoginHandler.GetCredentials()
        {

            parent.AuthenticationHandler();
            //wait user click OK or Cacel button
            parent.userInputCompleted.WaitOne();
            return parent.Credentials;
        }

        #endregion
    }
}
