using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IApiLinkTypeRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLinkTypeRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiLinkTypeRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>0b97dcb4ebf6baf0c2222e134ce6acdf</Hash>
</Codenesium>*/