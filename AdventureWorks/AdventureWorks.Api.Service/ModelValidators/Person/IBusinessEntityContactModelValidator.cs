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

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>55923ddf5af9efaf37220d866d95855b</Hash>
</Codenesium>*/