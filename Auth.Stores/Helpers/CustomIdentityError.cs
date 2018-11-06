using Microsoft.AspNetCore.Identity;

namespace Auth.Stores.Helpers
{
    public class CustomIdentityError : IdentityErrorDescriber
    {
        /// <summary>
        ///  Custom Identity Error Descriptions
        ///  Add to Startup.cs : services.AddIdentity<ApplicationUser, IdentityRole>().AddErrorDescriber<CustomIdentityError>();
        /// </summary>
        /// <returns></returns>
        public override IdentityError ConcurrencyFailure()
        {
            return new IdentityError { Code = nameof(ConcurrencyFailure), Description = $"There has been a concurrency error processing your credentials." };
        }

        public override IdentityError DefaultError()
        {
          return new IdentityError { Code = nameof(DefaultError), Description = $"An unknown error has occured processing your credentials." };
        }

        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError {Code = nameof(DuplicateEmail), Description = $"The Email Address... {email} already exists within the system. Please choose another Email Address and try again." };
        }

        public override IdentityError DuplicateRoleName(string role)
        {
            return new IdentityError { Code = nameof(DuplicateRoleName), Description = $"The Role... {role} already exists within the system. Please choose another name for the role and try again." };
        }

        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError { Code = nameof(DuplicateUserName), Description = $"The User Name... {userName} already exists within the system. Please choose an alternate name for the user and try again." };
        }

        public override IdentityError InvalidEmail(string email)
        {
            return new IdentityError { Code = nameof(InvalidEmail), Description = $"The Email... {email} could not be validated within the system. Please choose an alternate Email Address and try again." };
        }

        public override IdentityError InvalidRoleName(string role)
        {
            return new IdentityError { Code = nameof(InvalidRoleName), Description = $"The Role... {role} could not be validated within the system. Please choose an alternate Role name and try again." };
        }

        public override IdentityError InvalidToken()
        {
            return new IdentityError { Code = nameof(InvalidToken), Description = $"The Token could not be validated within the system. Please try the request again." };
        }

        public override IdentityError InvalidUserName(string userName)
        {
            return new IdentityError { Code = nameof(InvalidUserName), Description = $"The User Name... {userName} could not be validated within the system. Please choose an alternate User Name and try again." };
        }

        public override IdentityError LoginAlreadyAssociated()
        {
            return new IdentityError { Code = nameof(LoginAlreadyAssociated), Description = $"The External Login has already been associated with an account." };
        }

        public override IdentityError PasswordMismatch()
        {
            return new IdentityError { Code = nameof(PasswordMismatch), Description = $"There has been a password mismatch error. Please reenter your passwords and try your request again." };
        }

        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError { Code = nameof(PasswordRequiresDigit), Description = $"The password does not contain a numeric character. Please enter at least 1 numeric character for your password entry." };
        }

        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError { Code = nameof(PasswordRequiresLower), Description = $"The password does not contain a lower case letter. Please enter at least 1 lower case letter for your password entry." };
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError { Code = nameof(PasswordRequiresNonAlphanumeric), Description = $"The password does not contain a non-alphanumeric character i.e. (-!#~). Please enter at least 1 non-alphanumeric character i.e. (-!#~) for your password entry." };
        }

        public override IdentityError PasswordRequiresUniqueChars(int uniqueChars)
        {
            return new IdentityError { Code = nameof(PasswordRequiresUniqueChars), Description = $"The password does not meet the minimum number of unique characters. Please enter more then {uniqueChars} of unique characters for your password entry." };
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError { Code = nameof(PasswordRequiresUpper), Description = $"The password does not contain an upper case letter. Please enter at least 1 upper case letter for your password entry." };
        }

        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError { Code = nameof(PasswordTooShort), Description = $"The password is to short. You entered only {length} characters. Please enter the required number of characters for your password entry." };
        }

        public override IdentityError RecoveryCodeRedemptionFailed()
        {
            return new IdentityError { Code = nameof(RecoveryCodeRedemptionFailed), Description = $"The recovery code redemption has failed to process correctly. Please retry the password recovery again." };
        }

        public override IdentityError UserAlreadyHasPassword()
        {
            return new IdentityError { Code = nameof(UserAlreadyHasPassword), Description = $"The user already has a password within the system." };
        }

        public override IdentityError UserAlreadyInRole(string role)
        {
            return new IdentityError { Code = nameof(UserAlreadyInRole), Description = $"The user is already in the specified role {role}. Please choose another role to assign the user to." };
        }

        public override IdentityError UserLockoutNotEnabled()
        {
            return new IdentityError { Code = nameof(UserLockoutNotEnabled), Description = $"Account lockout is not enabled for this system." };
        }

        public override IdentityError UserNotInRole(string role)
        {
            return new IdentityError { Code = nameof(UserNotInRole), Description = $"The user is not in the specified role...{role}. The user will need to be added to this role...{role}" };
        }
    }
}