using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiAWBuildVersionModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiAWBuildVersionModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiAWBuildVersionModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>1e47853b7576995078d012ee12760aed</Hash>
</Codenesium>*/