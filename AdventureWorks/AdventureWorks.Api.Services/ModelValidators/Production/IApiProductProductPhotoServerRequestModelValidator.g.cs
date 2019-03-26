using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiProductProductPhotoServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductProductPhotoServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductProductPhotoServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>5287d7e61526e9452af67765ed2dbb9f</Hash>
</Codenesium>*/