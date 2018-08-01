using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public interface IApiCommentsRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCommentsRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCommentsRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>d8faacb98e49507a6de2269a8c2310c7</Hash>
</Codenesium>*/