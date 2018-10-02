using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiPostTypeRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPostTypeRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPostTypeRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>e72bb66ec8e10fcd730d770f4674b67d</Hash>
</Codenesium>*/