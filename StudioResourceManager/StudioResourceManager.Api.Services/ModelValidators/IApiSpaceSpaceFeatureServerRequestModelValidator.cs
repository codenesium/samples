using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IApiSpaceSpaceFeatureServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSpaceSpaceFeatureServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpaceSpaceFeatureServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>4e82a58a6b0bf63f1664bd7b1b409c59</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/