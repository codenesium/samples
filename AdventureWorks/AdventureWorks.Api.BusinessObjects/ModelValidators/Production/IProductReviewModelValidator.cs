using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IProductReviewModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(ProductReviewModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, ProductReviewModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>4ceff0ea8a8b0fcdac0222f790b821cb</Hash>
</Codenesium>*/