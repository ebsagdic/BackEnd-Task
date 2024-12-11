using BackEnd_Task.Models;
using Core.ViewModels;
using FluentValidation;

namespace Service.Validations
{
    public class UserValidation:AbstractValidator<RegisterModel>
    {
        public UserValidation()
        {
            RuleFor(user => user.UserName)
            .NotEmpty().WithMessage("Username alanı boş olamaz.") 
            .MinimumLength(3).WithMessage("Username en az 3 karakter uzunluğunda olmalıdır.") 
            .MaximumLength(50).WithMessage("Username en fazla 50 karakter uzunluğunda olabilir."); 

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Password alanı boş olamaz.") 
                .MinimumLength(8).WithMessage("Password en az 8 karakter uzunluğunda olmalıdır.") 
                .Matches("[A-Z]").WithMessage("Password en az bir büyük harf içermelidir.")  
                .Matches("[a-z]").WithMessage("Password en az bir küçük harf içermelidir.")  
                .Matches("[0-9]").WithMessage("Password en az bir rakam içermelidir.") 
                .Matches("[^a-zA-Z0-9]").WithMessage("Password en az bir özel karakter içermelidir."); 

            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Email alanı boş olamaz.") 
                .EmailAddress().WithMessage("Geçerli bir email adresi giriniz."); 

            RuleFor(user => user.Role)
                .IsInEnum().WithMessage("Geçersiz kullanıcı rolü.");
        }
    }
}
