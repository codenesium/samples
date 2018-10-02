using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;

namespace TwitterNS.Api.Services
{
	public partial interface IApiUserRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiUserRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiUserRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>5e11ee397ab477741ef9325a3fdee2a4</Hash>
</Codenesium>*/