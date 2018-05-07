using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IProductReviewModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ProductReviewModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ProductReviewModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>74e6e5cb7aef13999cb0ef7bd970ccd8</Hash>
</Codenesium>*/