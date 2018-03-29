using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IStoreModelValidator
	{
		ValidationResult Validate(StoreModel entity);

		Task<ValidationResult> ValidateAsync(StoreModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>c51d88b4f6821bd100ce452018a639dd</Hash>
</Codenesium>*/