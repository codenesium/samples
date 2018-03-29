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

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>2adfb6de0584447d43ebd2cc585d0c26</Hash>
</Codenesium>*/