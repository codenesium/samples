using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IBusinessEntityModelValidator
	{
		ValidationResult Validate(BusinessEntityModel entity);

		Task<ValidationResult> ValidateAsync(BusinessEntityModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>1cbb5e2d4a69a66423821c6d7fc59e4c</Hash>
</Codenesium>*/