using ESPIOTNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services
{
	public partial interface IApiEfmigrationshistoryServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiEfmigrationshistoryServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiEfmigrationshistoryServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>99c2e06b200843dc8aa93974dbe421aa</Hash>
</Codenesium>*/