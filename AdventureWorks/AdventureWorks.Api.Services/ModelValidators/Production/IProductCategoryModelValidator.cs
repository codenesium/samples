using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
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
    <Hash>7244a62e0f43bb0bf14633c26f7387f1</Hash>
</Codenesium>*/