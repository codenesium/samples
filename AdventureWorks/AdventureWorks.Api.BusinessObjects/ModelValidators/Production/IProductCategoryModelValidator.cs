using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiProductCategoryRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductCategoryRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductCategoryRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>1f70046267e8e619410fbf2355c6ad69</Hash>
</Codenesium>*/