using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiPurchaseOrderHeaderRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPurchaseOrderHeaderRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPurchaseOrderHeaderRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>7fe04968965222d373bcdcbccdc3c9a1</Hash>
</Codenesium>*/