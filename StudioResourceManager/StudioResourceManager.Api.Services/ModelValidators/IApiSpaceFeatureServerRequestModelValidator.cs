using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IApiSpaceFeatureServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSpaceFeatureServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpaceFeatureServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>4cea746ec2f6b26d5496658173fd27f7</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/