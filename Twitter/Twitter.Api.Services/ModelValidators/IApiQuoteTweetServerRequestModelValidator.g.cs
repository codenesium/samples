using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;

namespace TwitterNS.Api.Services
{
	public partial interface IApiQuoteTweetServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiQuoteTweetServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiQuoteTweetServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>9fd8f6987bc7d51263ede48b90f381e3</Hash>
</Codenesium>*/