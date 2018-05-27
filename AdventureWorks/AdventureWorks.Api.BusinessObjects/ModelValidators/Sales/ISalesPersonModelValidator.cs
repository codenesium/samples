using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiSalesPersonRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSalesPersonRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesPersonRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>e56c1b119e8524b0b0713c37c3c04a50</Hash>
</Codenesium>*/