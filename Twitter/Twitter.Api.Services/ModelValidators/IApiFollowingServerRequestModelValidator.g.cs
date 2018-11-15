using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;

namespace TwitterNS.Api.Services
{
	public partial interface IApiFollowingServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiFollowingServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiFollowingServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>b442213eacd026d21c6cfebcdd2a5818</Hash>
</Codenesium>*/