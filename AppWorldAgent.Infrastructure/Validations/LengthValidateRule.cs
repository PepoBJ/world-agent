
namespace AppWorldAgent.Infrastructure.Validations
{
    using AppWorldAgent.Infrastructure.Services.Validations;
    using System;
    using System.Globalization;
    using System.Net.Mail;

    public class CompanyLengthValidateRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }
        public long Length { get; set; }
        public bool Check(T value)
        {
            if (value == null)
                return false;

            if (!string.IsNullOrEmpty(this.ValidationMessage))
                this.ValidationMessage = string.Format(this.ValidationMessage, this.Length);

            var str = value as string;
            if (str.Length == this.Length)
                return true;

            return false;
        }
    }

    public class StringLengthValidateRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }
        public long Length { get; set; }
        public bool Check(T value)
        {
            if (value == null)
                return false;

            if (!string.IsNullOrEmpty(this.ValidationMessage))
                this.ValidationMessage = string.Format(this.ValidationMessage, this.Length);

            var str = value as string;
            if (str.Length <= Length)
                return true;

            return false;
        }
    }

    public class StringMinLength<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }
        public long Length { get; set; }
        public bool Check(T value)
        {
            if (value == null)
                return false;

            if (Length == 0)
                Length = 1;

            if (!string.IsNullOrEmpty(this.ValidationMessage))
                this.ValidationMessage = string.Format(this.ValidationMessage, this.Length);

            var str = value as string;
            if (str.Length < Length)
                return false;

            return true;
        }
    }

    public class StringMaxLength<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }
        public long Length { get; set; }
        public bool Check(T value)
        {
            if (value == null)
                return false;

            if (Length == 0)
                Length = 10;

            var str = value as string;
            if (str.Length > Length)
                return false;

            return true;
        }
    }

    public class IntegerRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }
        public bool Check(T value)
        {
            if (value == null)
                return false;
            var str = value as string;
            if (str.Length > 0)
            {
                foreach (var item in str)
                {
                    if (!char.IsNumber(item))
                        return false;
                }
            }
            else
                return false;

            return true;
        }
    }

    public class DecimalRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }
        public bool Check(T value)
        {
            if (value == null)
                return false;
            var str = value as string;

            CultureInfo cc = System.Threading.Thread.CurrentThread.CurrentCulture;
            foreach (var item in str)
            {
                if (!char.IsNumber(item))
                {
                    if (!(item.ToString() == cc.NumberFormat.NumberDecimalSeparator))
                        return false;
                }
            }
            return true;
        }
    }

    public class EmailValidationRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }
        public bool Check(T value)
        {
            if (value == null)
                return false;
            var emailaddress = value as string;

            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }

}
