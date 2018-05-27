using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiAWBuildVersionRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiAWBuildVersionRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiAWBuildVersionRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>9a1edecaebb649ae6934d62db5426341</Hash>
</Codenesium>*/