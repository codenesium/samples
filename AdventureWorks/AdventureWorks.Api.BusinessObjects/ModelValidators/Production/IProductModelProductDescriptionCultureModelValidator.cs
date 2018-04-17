using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IProductModelProductDescriptionCultureModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(ProductModelProductDescriptionCultureModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, ProductModelProductDescriptionCultureModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>034fc7f657f62477f0f918185103dedf</Hash>
</Codenesium>*/