using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IProductModelProductDescriptionCultureModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ProductModelProductDescriptionCultureModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ProductModelProductDescriptionCultureModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>790a88bed4bb6fcd112daf690e3b4ee9</Hash>
</Codenesium>*/