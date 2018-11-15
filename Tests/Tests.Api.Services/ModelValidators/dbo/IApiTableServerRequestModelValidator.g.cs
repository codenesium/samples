using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
	public partial interface IApiTableServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiTableServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiTableServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f86491282c185f5e5b104c8dc1ec7618</Hash>
</Codenesium>*/