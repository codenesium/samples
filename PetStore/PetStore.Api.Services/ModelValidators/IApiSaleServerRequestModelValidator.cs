using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public partial interface IApiSaleServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSaleServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSaleServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>0ef034c66d581f8a57bc2f056751dd71</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/