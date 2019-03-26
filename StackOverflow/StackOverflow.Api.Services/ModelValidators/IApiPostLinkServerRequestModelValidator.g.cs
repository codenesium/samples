using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiPostLinkServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPostLinkServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPostLinkServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>a21fc47881cffc9701ee54e255f59a6c</Hash>
</Codenesium>*/