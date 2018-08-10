using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiPipelineStepStatusRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepStatusRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepStatusRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>51a953d4d6202e5960ac755660724ca2</Hash>
</Codenesium>*/