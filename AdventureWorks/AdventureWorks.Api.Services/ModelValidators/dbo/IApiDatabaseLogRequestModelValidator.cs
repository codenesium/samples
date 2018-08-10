using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiDatabaseLogRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDatabaseLogRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiDatabaseLogRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>6175697bf7b817ab762d652fae0b7a14</Hash>
</Codenesium>*/