using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiProductCategoryRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductCategoryRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductCategoryRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>08646ad70b95c7ef468cff4a77f8f925</Hash>
</Codenesium>*/