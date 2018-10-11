using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;

namespace TwitterNS.Api.Services
{
	public partial interface IApiFollowerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiFollowerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiFollowerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>cfb6c9d440657334bdd50ac799f8b50e</Hash>
</Codenesium>*/