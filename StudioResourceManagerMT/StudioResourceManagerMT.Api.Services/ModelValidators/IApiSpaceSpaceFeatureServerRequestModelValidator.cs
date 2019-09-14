using FluentValidation.Results;
using StudioResourceManagerMTNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IApiSpaceSpaceFeatureServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSpaceSpaceFeatureServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpaceSpaceFeatureServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>9d6c816dd1f8c0df2db915cdbc3f9084</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/