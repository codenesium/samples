using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiPipelineStepNoteServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPipelineStepNoteServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStepNoteServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>e9218c7c4f1175126f5f1df0fcc11632</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/