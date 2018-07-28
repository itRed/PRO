using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRO
{
    class InfoUser
    {
        private int userId;
        private string userName;
        private string userPass;

        public InfoUser() { 
        }

        public InfoUser(int userId, string userName, string userPass) {
            this.userId = userId;
            this.userName = userName;
            this.userPass = userPass;
        }

        public void setUserId(int userId) {
            this.userId = userId;
        }

        public int getUserId() {
            return userId;
        }

        public void setUserName(string userName) {
            this.userName = userName;
        }

        public string getUserName() {
            return userName;
        }

        public void setUserPass(string userPass) {
            this.userPass = userPass;
        }

        public string getUserPass() {
            return userPass;
        }

    }
}
