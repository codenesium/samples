using FluentValidation.Results;
using StudioResourceManagerMTNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IApiSpaceFeatureServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSpaceFeatureServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpaceFeatureServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>d005c73cc63270f317ff28c98956ee45</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/