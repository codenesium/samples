using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IPersonPhoneModelValidator
	{
		ValidationResult Validate(PersonPhoneModel entity);

		Task<ValidationResult> ValidateAsync(PersonPhoneModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>d0238b70c4be84d6d894f768c67e4695</Hash>
</Codenesium>*/