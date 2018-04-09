using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IShiftModelValidator
	{
		ValidationResult Validate(ShiftModel entity);

		Task<ValidationResult> ValidateAsync(ShiftModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>10231af33cb9e66c9ff45067fe00289b</Hash>
</Codenesium>*/