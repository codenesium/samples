using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IProductModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ProductModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ProductModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>5b25c9451ef0b3694ebaa82b11026c54</Hash>
</Codenesium>*/