using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiPurchaseOrderHeaderRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPurchaseOrderHeaderRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPurchaseOrderHeaderRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>25821a8ff36081b62f963808c1f656e2</Hash>
</Codenesium>*/