using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiPurchaseOrderDetailRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPurchaseOrderDetailRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPurchaseOrderDetailRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>446623810e2fb6248e58b601025ccefa</Hash>
</Codenesium>*/