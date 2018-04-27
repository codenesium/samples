using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IPipelineStepStatusModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(PipelineStepStatusModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, PipelineStepStatusModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>9382e865dff1c5117aec8b9369e0ef95</Hash>
</Codenesium>*/