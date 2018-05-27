using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiDatabaseLogRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDatabaseLogRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiDatabaseLogRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>c1dc123850965d52b88b724a5bde4344</Hash>
</Codenesium>*/