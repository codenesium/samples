using CADNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiAddressServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiAddressServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiAddressServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>ce5e7b8e4f8df26d2bad0446c310e3bc</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/