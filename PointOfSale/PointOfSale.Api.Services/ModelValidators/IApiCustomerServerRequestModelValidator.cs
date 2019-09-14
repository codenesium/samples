using FluentValidation.Results;
using PointOfSaleNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PointOfSaleNS.Api.Services
{
	public partial interface IApiCustomerServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCustomerServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCustomerServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>81680613167e69d16cf11645a60ee297</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/