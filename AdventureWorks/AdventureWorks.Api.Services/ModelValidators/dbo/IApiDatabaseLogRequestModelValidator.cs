using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IApiDatabaseLogRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDatabaseLogRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiDatabaseLogRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>2ae257ec0db2ab557dcaca4d7476ff45</Hash>
</Codenesium>*/