using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
	public partial interface IApiSelfReferenceRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSelfReferenceRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSelfReferenceRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>5c36d8674fb46985ae068e3d62d9f5cd</Hash>
</Codenesium>*/