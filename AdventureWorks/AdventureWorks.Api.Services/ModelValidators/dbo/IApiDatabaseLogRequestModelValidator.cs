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
    <Hash>7efc33b04da1f5a302452f658a98bbbe</Hash>
</Codenesium>*/