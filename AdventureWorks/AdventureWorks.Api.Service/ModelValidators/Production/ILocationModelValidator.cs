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

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>cd8195bcc67edc0cbc2848aeaa9b2ec1</Hash>
</Codenesium>*/