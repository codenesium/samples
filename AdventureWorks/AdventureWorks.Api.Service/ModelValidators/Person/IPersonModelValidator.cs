using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IPersonModelValidator
	{
		ValidationResult Validate(PersonModel entity);

		Task<ValidationResult> ValidateAsync(PersonModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>89801b10922d83967707f568520ca654</Hash>
</Codenesium>*/