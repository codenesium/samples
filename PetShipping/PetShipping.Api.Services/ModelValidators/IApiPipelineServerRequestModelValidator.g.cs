using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiPipelineServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPipelineServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPipelineServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>1399d400095f13a6869fb87cbbddeb06</Hash>
</Codenesium>*/