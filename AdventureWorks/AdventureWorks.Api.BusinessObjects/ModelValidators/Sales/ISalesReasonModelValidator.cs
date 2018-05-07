using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface ISalesReasonModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(SalesReasonModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, SalesReasonModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>77512645f47c173ad63e20cf50c55fd4</Hash>
</Codenesium>*/