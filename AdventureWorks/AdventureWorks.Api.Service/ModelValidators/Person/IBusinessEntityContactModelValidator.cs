using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IBusinessEntityContactModelValidator
	{
		ValidationResult Validate(BusinessEntityContactModel entity);

		Task<ValidationResult> ValidateAsync(BusinessEntityContactModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>f276879533027eb6dd8482944309bb0e</Hash>
</Codenesium>*/