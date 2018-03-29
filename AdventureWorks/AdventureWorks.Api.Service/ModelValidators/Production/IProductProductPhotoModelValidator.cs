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

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>c310f1811891f328e59ae41f1f6ce4d7</Hash>
</Codenesium>*/