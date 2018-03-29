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

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>900510af24ccca017c2d2740562f3a51</Hash>
</Codenesium>*/