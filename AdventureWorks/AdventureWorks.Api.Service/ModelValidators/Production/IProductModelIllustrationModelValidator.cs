using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IProductModelIllustrationModelValidator
	{
		ValidationResult Validate(ProductModelIllustrationModel entity);

		Task<ValidationResult> ValidateAsync(ProductModelIllustrationModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>7de228af555e1235588c87bedc9d6269</Hash>
</Codenesium>*/