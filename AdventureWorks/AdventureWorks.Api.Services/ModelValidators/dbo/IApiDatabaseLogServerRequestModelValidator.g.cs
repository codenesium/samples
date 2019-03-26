using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiDatabaseLogServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDatabaseLogServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiDatabaseLogServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>d2a7ca0cc5353842fc9f77e7ff650b53</Hash>
</Codenesium>*/