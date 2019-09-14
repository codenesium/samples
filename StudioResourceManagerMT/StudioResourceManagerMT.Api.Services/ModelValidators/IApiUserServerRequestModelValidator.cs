using FluentValidation.Results;
using StudioResourceManagerMTNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IApiUserServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiUserServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiUserServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>ced1f331022398004ab770decf6e4f14</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/