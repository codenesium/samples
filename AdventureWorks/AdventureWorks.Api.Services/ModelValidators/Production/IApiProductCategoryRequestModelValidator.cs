using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IApiProductCategoryRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductCategoryRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductCategoryRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>948a91cb36c0f4c12016df471027669e</Hash>
</Codenesium>*/