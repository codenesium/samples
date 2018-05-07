using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IProductModelModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ProductModelModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ProductModelModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>48e4c86e1dcb7235a76e8e09e3710268</Hash>
</Codenesium>*/