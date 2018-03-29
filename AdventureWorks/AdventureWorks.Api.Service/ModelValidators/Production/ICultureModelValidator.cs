using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface ICultureModelValidator
	{
		ValidationResult Validate(CultureModel entity);

		Task<ValidationResult> ValidateAsync(CultureModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>3f48fb390c2645a07d799e8f9e390d19</Hash>
</Codenesium>*/