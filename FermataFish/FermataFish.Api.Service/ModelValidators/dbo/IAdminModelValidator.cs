using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.Service
{
	public interface IAdminModelValidator
	{
		ValidationResult Validate(AdminModel entity);

		Task<ValidationResult> ValidateAsync(AdminModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>eca6c79a93964f9b2bdae54e2736fcf0</Hash>
</Codenesium>*/