using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IContactTypeModelValidator
	{
		ValidationResult Validate(ContactTypeModel entity);

		Task<ValidationResult> ValidateAsync(ContactTypeModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>08e0401b8a804a9dc705712f0a38d9c7</Hash>
</Codenesium>*/