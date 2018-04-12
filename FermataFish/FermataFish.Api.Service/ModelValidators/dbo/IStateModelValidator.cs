using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.Service
{
	public interface IStateModelValidator
	{
		ValidationResult Validate(StateModel entity);

		Task<ValidationResult> ValidateAsync(StateModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>101c0a4cda23ef75433fe1d26d7e9ba8</Hash>
</Codenesium>*/