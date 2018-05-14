using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiDatabaseLogModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDatabaseLogModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiDatabaseLogModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>4b202e3d21f895b6cb9726846896c52f</Hash>
</Codenesium>*/