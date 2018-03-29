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

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>6715070c00c3d7c6a6f83503cf9b1153</Hash>
</Codenesium>*/