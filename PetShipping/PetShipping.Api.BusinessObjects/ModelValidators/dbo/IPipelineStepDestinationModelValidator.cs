using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IPipelineStepDestinationModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(PipelineStepDestinationModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, PipelineStepDestinationModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>0c3cae61a08f313a52dbe0a79421315c</Hash>
</Codenesium>*/