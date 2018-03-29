using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface ICurrencyModelValidator
	{
		ValidationResult Validate(CurrencyModel entity);

		Task<ValidationResult> ValidateAsync(CurrencyModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>6bcb6af1ebaae35aefbb9f5a907d5035</Hash>
</Codenesium>*/