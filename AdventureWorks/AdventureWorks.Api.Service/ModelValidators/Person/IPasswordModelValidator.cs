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

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>2d75f11b8653ed68f573052901f9f4ce</Hash>
</Codenesium>*/