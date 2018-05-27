using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiProductSubcategoryRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductSubcategoryRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductSubcategoryRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>34a6fcf158f2aa8e98340842591ebbe3</Hash>
</Codenesium>*/