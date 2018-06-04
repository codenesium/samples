using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
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
    <Hash>f90faaa0ec6289c8eb7cadf6256665ea</Hash>
</Codenesium>*/