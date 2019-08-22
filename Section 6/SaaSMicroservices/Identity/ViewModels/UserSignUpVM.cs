using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Identity.ViewModels
{
    public class UserSignUpVM : INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _password;

        [Required]
        [MaxLength(100)]
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    NotifyPropertyChanged(u => u.FirstName);
                }
            }
        }

        [Required]
        [MaxLength(100)]
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    NotifyPropertyChanged(u => u.LastName);
                }
            }
        }

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
