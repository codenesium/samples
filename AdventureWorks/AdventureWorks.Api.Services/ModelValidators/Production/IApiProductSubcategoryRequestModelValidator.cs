using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IApiProductSubcategoryRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductSubcategoryRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductSubcategoryRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>5ef8d21db25bdb8cfbee23f08fb58d66</Hash>
</Codenesium>*/