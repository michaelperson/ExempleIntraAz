namespace ExempleIntraAz.Models
{
    public class LoginModel
    {
        string _pseudo;
        string _password;
        string _repeatPassword;

        public string Pseudo
        {
            get
            {
                return _pseudo;
            }

            set
            {
                _pseudo = value;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
            }
        }

        public string RepeatPassword
        {
            get
            {
                return _repeatPassword;
            }

            set
            {
                _repeatPassword = value;
            }
        }
    }
}
