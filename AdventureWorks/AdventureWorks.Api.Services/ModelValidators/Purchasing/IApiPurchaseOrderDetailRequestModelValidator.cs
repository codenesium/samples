using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiPurchaseOrderDetailRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPurchaseOrderDetailRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPurchaseOrderDetailRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>3e45c393070a3cf614855d2ad7eec217</Hash>
</Codenesium>*/