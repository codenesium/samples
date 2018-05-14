using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiProductSubcategoryModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductSubcategoryModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductSubcategoryModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>03e359d323e3216af35bbbefb0699a7c</Hash>
</Codenesium>*/