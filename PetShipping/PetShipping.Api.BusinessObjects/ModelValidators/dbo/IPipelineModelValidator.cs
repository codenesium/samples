using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IPipelineModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(PipelineModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, PipelineModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>9d8114461ec204c77164a24baae674eb</Hash>
</Codenesium>*/