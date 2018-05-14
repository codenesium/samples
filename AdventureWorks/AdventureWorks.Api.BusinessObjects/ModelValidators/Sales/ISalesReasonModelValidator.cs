using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiSalesReasonModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSalesReasonModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesReasonModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>0419a16ed4d9c710bd0d27922de95d06</Hash>
</Codenesium>*/