using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.Services
{
	public interface IApiSaleRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSaleRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSaleRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>b25a7720a33a4a6bc5d724ba89abeab5</Hash>
</Codenesium>*/