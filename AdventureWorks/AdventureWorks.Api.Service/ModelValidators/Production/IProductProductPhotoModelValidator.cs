using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IProductProductPhotoModelValidator
	{
		ValidationResult Validate(ProductProductPhotoModel entity);

		Task<ValidationResult> ValidateAsync(ProductProductPhotoModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>e0a36986accfa5ebb4c565213440e378</Hash>
</Codenesium>*/