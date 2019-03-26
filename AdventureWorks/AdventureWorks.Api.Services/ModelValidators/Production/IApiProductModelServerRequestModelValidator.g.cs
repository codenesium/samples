using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiProductModelServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductModelServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductModelServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>fd71a52b26169fecfb128b07883671f0</Hash>
</Codenesium>*/