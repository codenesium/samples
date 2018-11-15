using FluentValidation.Results;
using StudioResourceManagerMTNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IApiRateServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiRateServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiRateServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>98df9ca794991f8d6855311b3c322383</Hash>
</Codenesium>*/