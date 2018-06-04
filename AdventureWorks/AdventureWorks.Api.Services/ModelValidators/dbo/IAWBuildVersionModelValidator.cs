using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiAWBuildVersionRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiAWBuildVersionRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiAWBuildVersionRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>0f1a3efbb4627869a78c848b5d5f5dda</Hash>
</Codenesium>*/