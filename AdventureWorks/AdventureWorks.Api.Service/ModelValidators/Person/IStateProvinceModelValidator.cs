using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IStateProvinceModelValidator
	{
		ValidationResult Validate(StateProvinceModel entity);

		Task<ValidationResult> ValidateAsync(StateProvinceModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>9102e844d828477f8f077363ee5eee25</Hash>
</Codenesium>*/