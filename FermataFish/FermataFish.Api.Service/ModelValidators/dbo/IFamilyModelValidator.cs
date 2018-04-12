using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.Service
{
	public interface IFamilyModelValidator
	{
		ValidationResult Validate(FamilyModel entity);

		Task<ValidationResult> ValidateAsync(FamilyModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>bef52c46365b27fc74845ab21fe6fea1</Hash>
</Codenesium>*/