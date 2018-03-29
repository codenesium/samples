using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface ILocationModelValidator
	{
		ValidationResult Validate(LocationModel entity);

		Task<ValidationResult> ValidateAsync(LocationModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>aeaea503b3b674d5b16501f2a183d039</Hash>
</Codenesium>*/