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
    <Hash>73984ef9e6a15b7489a444e4238a02ad</Hash>
</Codenesium>*/