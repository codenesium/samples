using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IProductPhotoModelValidator
	{
		ValidationResult Validate(ProductPhotoModel entity);

		Task<ValidationResult> ValidateAsync(ProductPhotoModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>ddb1b0225f6688fc9f0d95919babe709</Hash>
</Codenesium>*/