using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.Services
{
	public interface IApiPipelineStatusRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPipelineStatusRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineStatusRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>e9de62c3cd582a9da89273cdeac67166</Hash>
</Codenesium>*/