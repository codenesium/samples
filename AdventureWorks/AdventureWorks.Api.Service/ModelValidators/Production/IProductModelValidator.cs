using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IProductModelValidator
	{
		ValidationResult Validate(ProductModel entity);

		Task<ValidationResult> ValidateAsync(ProductModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>cc66b73eb70f49e646fb55ad1b477cc9</Hash>
</Codenesium>*/