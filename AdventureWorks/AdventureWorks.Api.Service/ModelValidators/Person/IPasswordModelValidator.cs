using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IPasswordModelValidator
	{
		ValidationResult Validate(PasswordModel entity);

		Task<ValidationResult> ValidateAsync(PasswordModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>d490a465e351537537c935330f80bf4d</Hash>
</Codenesium>*/