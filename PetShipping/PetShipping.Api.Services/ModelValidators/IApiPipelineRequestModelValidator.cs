using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiPipelineRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPipelineRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>324cd4e9128711dad30a0642e1a9e372</Hash>
</Codenesium>*/