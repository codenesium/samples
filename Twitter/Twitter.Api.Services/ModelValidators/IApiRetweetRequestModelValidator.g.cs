using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;

namespace TwitterNS.Api.Services
{
	public partial interface IApiRetweetRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiRetweetRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiRetweetRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>bf97910d7d7eac411e42161e731c84c2</Hash>
</Codenesium>*/