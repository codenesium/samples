using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface IBusinessEntityAddressModelValidator
	{
		ValidationResult Validate(BusinessEntityAddressModel entity);

		Task<ValidationResult> ValidateAsync(BusinessEntityAddressModel entity);
		void CreateMode();

		void UpdateMode();

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>e5f7f2cbe0fa545986634f8fa5f5b99b</Hash>
</Codenesium>*/