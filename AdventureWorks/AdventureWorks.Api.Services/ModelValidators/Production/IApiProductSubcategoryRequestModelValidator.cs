using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiProductSubcategoryRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductSubcategoryRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductSubcategoryRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>bae0b4408e43156ef86ba964b472ffea</Hash>
</Codenesium>*/