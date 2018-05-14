using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiProductModelProductDescriptionCultureModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductModelProductDescriptionCultureModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductModelProductDescriptionCultureModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>91ac74965957720f8801e8a363438503</Hash>
</Codenesium>*/