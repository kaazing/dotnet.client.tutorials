/**
 * Copyright (c) 2007-2015, Kaazing Corporation. All rights reserved.
 */
using Kaazing.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JmsDemo
{
    class DemoLoginHandler : LoginHandler
    {
        /**
         * Challenge handler for Basic authentication. See RFC 2617.
         */
        private MainPage parent;

        public DemoLoginHandler(MainPage mainPage)
        {
            parent = mainPage;
        }

        //handle Challenge request from server
        public PasswordAuthentication GetCredentials()
        {
            parent.PopupLoginPage();

            //wait user click OK or Cacel button
            parent.userInputCompleted.WaitOne();
            return parent.Credentials;
        }
    }
}

