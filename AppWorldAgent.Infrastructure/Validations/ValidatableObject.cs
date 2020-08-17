namespace AppWorldAgent.Infrastructure.Validations
{
    using AppWorldAgent.Infrastructure.Services.Validations;
    using ViewModels;
    using System.Collections.Generic;
    using System.Linq;
    using System;

    public class ValidatableObject<T> : ExtendedBindableObject, IValidity
    {
        private readonly List<IValidationRule<T>> _validations;
        public List<IValidationRule<T>> Validations => _validations;

        private T _value;
        public T Value
        {
            get { return _value; }
            set { _value = value; RaisePropertyChanged(() => Value); }
        }

        private List<string> _errors;
        public List<string> Errors
        {
            get { return _errors;}
            set { _errors = value; RaisePropertyChanged(() => Errors);}
        }

        private bool _isValid;
        public bool IsValid
        {
            get { return _isValid; }
            set {_isValid = value; RaisePropertyChanged(() => IsValid);}
        }

        private bool _isWarning;
        public bool IsWarning
        {
            get { return _isWarning; }
            set { _isWarning = value; RaisePropertyChanged(() => IsWarning); }
        }

        public ValidatableObject()
        {
            _isValid = true;
            _errors = new List<string>();
            _validations = new List<IValidationRule<T>>();
        }

        public bool Validate()
        {
            Errors.Clear();

            IEnumerable<string> errors = _validations.Where(v => !v.Check(Value))
                .Select(v => v.ValidationMessage);

            Errors = errors.ToList();
            IsValid = !Errors.Any();

            return this.IsValid;
        }

        public static implicit operator ValidatableObject<T>(bool v)
        {
            throw new NotImplementedException();
        }
    }
}
