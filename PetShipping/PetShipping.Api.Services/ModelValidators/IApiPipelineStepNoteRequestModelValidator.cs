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
    <Hash>c8c2bcda58f1841530a161bee897a6a9</Hash>
</Codenesium>*/