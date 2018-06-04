using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
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
    <Hash>f325f05592ccb4d6049640b039937fdc</Hash>
</Codenesium>*/