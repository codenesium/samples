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
    <Hash>f2be637940a190a11ca0cb254c134bdb</Hash>
</Codenesium>*/