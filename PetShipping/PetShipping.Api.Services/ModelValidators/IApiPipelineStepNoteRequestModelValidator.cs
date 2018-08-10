using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiPipelineStepNoteRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepNoteRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepNoteRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>68a5d4ed5095f72b3c3e17528a1afc85</Hash>
</Codenesium>*/