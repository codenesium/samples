using System.Threading.Tasks;
using FluentValidation.Results;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.Service
{
	public interface IStudioModelValidator
	{
		ValidationResult Validate(StudioModel entity);

		Task<ValidationResult> ValidateAsync(StudioModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>e4b31d9938a3113dbcd83803529d9e7c</Hash>
</Codenesium>*/