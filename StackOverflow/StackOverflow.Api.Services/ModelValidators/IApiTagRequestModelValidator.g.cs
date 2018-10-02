using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiTagRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTagRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTagRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>ff14fc7a563f08634f604730a8ae7ef9</Hash>
</Codenesium>*/