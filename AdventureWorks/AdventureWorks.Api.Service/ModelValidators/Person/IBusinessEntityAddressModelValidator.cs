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

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>d43aa198653a23b6d28625ad72105633</Hash>
</Codenesium>*/