using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IApiPipelineStatusModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPipelineStatusModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStatusModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>04c1a358e734142df5ae024c16b344a9</Hash>
</Codenesium>*/