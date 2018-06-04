using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
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
    <Hash>567184cc1dee4397e1089a963663ec5c</Hash>
</Codenesium>*/