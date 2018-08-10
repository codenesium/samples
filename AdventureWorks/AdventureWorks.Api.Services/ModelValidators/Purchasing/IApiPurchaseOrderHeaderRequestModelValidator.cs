using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiPurchaseOrderHeaderRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPurchaseOrderHeaderRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPurchaseOrderHeaderRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>ef7a6628c6e22e68c833c439ad9f299a</Hash>
</Codenesium>*/