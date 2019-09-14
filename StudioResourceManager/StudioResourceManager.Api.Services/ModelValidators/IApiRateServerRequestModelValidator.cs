using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IApiRateServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiRateServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiRateServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>c5a157ac1276505e36e7bb77df787594</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/