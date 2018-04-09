using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IProductModelProductDescriptionCultureModelValidator
	{
		ValidationResult Validate(ProductModelProductDescriptionCultureModel entity);

		Task<ValidationResult> ValidateAsync(ProductModelProductDescriptionCultureModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>fa3e293458330e1d825b56204c3320e2</Hash>
</Codenesium>*/