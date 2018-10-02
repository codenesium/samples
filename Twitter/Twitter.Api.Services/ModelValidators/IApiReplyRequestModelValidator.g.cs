using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;

namespace TwitterNS.Api.Services
{
	public partial interface IApiReplyRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiReplyRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiReplyRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>47fd7971a179c730039b6ac0b8216c59</Hash>
</Codenesium>*/