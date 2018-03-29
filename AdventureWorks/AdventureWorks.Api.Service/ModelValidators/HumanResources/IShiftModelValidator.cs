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

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>8ceb612db72b417aa54e837919e63eab</Hash>
</Codenesium>*/