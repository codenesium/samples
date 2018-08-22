using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiBadgesRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiBadgesRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiBadgesRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>af3a493734e313f1f7a6da50efb66fd8</Hash>
</Codenesium>*/