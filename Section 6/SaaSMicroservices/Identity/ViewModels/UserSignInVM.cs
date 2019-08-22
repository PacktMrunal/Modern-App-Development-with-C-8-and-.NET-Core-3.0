using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Identity.ViewModels
{
    public class UserSignInVM : INotifyPropertyChanged
    {
        private string _email;
        private string _password;

        [Required]
        [EmailAddress]
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    NotifyPropertyChanged(u => u.Email);
                }
            }
        }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(6)]
        [MaxLength(32)]
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    NotifyPropertyChanged(u => u.Password);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged<T>(Expression<Func<UserSignUpVM, T>> property)
        {
            if (PropertyChanged != null)
            {
                var memberExpression = property.Body as MemberExpression;
                string propertyName = memberExpression.Member.Name;
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
