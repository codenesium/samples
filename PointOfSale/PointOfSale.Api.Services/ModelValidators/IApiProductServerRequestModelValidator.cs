using FluentValidation.Results;
using PointOfSaleNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PointOfSaleNS.Api.Services
{
	public partial interface IApiProductServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>d7d33943864e64a105947f34e0819a60</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/