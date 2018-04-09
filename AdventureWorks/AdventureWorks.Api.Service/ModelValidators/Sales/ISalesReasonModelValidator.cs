using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface ISalesReasonModelValidator
	{
		ValidationResult Validate(SalesReasonModel entity);

		Task<ValidationResult> ValidateAsync(SalesReasonModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>bce6671018e67405b43771139577720b</Hash>
</Codenesium>*/