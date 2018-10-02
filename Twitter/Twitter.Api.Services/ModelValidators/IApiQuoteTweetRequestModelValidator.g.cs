using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;

namespace TwitterNS.Api.Services
{
	public partial interface IApiQuoteTweetRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiQuoteTweetRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiQuoteTweetRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f513514c3b1ca252155ea6a1efde5e22</Hash>
</Codenesium>*/