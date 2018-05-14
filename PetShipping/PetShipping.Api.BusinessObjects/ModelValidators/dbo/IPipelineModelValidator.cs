using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IApiPipelineModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPipelineModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>5d87f5c6efccc1bdd1b0e5a015dc9956</Hash>
</Codenesium>*/