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

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>7be03b255f89dd5d80e4f9630dd7479a</Hash>
</Codenesium>*/