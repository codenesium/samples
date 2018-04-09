using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IProductDescriptionModelValidator
	{
		ValidationResult Validate(ProductDescriptionModel entity);

		Task<ValidationResult> ValidateAsync(ProductDescriptionModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>61c174e695fc2344c4f2553ff8b01406</Hash>
</Codenesium>*/