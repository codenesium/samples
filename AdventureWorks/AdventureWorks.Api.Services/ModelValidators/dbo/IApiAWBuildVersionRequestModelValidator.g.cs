using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiAWBuildVersionRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiAWBuildVersionRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiAWBuildVersionRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>12d3d3282159294c2b03d755fa15076b</Hash>
</Codenesium>*/