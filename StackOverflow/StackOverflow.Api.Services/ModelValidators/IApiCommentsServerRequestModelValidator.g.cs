using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiCommentsServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCommentsServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCommentsServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>577187d483c688eb45368d090c5b4d3e</Hash>
</Codenesium>*/