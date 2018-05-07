using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IPipelineStepStatusModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(PipelineStepStatusModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, PipelineStepStatusModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>a91bef8f43e751faef20057efcb3d80a</Hash>
</Codenesium>*/