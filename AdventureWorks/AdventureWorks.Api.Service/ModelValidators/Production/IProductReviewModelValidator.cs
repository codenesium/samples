using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IProductReviewModelValidator
	{
		ValidationResult Validate(ProductReviewModel entity);

		Task<ValidationResult> ValidateAsync(ProductReviewModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>0590ed60026ec0cbeae2023f853fabe0</Hash>
</Codenesium>*/