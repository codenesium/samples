using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IProductModelModelValidator
	{
		ValidationResult Validate(ProductModelModel entity);

		Task<ValidationResult> ValidateAsync(ProductModelModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>764837c1301121f92f8bc85cdf043c7e</Hash>
</Codenesium>*/