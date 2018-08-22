using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiCommentsRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCommentsRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCommentsRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>ed38750bf09d0f5be80b0d47ad04a265</Hash>
</Codenesium>*/