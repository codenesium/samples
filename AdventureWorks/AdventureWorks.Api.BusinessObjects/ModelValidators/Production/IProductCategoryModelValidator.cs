using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiProductCategoryModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductCategoryModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductCategoryModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>ca9cd5ab1fd00074ae1bb9802db23450</Hash>
</Codenesium>*/