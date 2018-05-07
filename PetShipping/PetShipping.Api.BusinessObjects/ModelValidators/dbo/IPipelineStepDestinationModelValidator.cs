using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IPipelineStepDestinationModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(PipelineStepDestinationModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, PipelineStepDestinationModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>4098800bf0305abd9b28dace9861ffd8</Hash>
</Codenesium>*/