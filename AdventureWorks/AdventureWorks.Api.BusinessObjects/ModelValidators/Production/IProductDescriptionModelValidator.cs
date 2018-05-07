using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IProductDescriptionModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ProductDescriptionModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ProductDescriptionModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f174f3f7eb2b8d7088374b2ea7b04585</Hash>
</Codenesium>*/