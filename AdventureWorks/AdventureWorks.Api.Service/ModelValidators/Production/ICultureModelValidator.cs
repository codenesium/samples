using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface ICultureModelValidator
	{
		ValidationResult Validate(CultureModel entity);

		Task<ValidationResult> ValidateAsync(CultureModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>2c50ea1fc009d818b10fb549e2262332</Hash>
</Codenesium>*/