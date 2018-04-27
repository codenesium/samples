using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IPipelineStepModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(PipelineStepModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, PipelineStepModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>3087a0f805e0e967e3682818582178d7</Hash>
</Codenesium>*/