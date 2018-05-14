using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IApiSaleModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSaleModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSaleModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>18910a8c516848ab6e93fcd94d6f0e71</Hash>
</Codenesium>*/