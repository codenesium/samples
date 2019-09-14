using FluentValidation.Results;
using StudioResourceManagerMTNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IApiSpaceServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSpaceServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpaceServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>8c94728f967efe73bf0a46079d3b6a63</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/