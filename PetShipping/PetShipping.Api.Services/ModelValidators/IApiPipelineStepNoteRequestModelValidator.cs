using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public interface IApiPipelineStepNoteRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepNoteRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepNoteRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>8a6d648b11cd559a1295f05a4367eeca</Hash>
</Codenesium>*/