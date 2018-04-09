using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Service
{
	public interface ICustomerModelValidator
	{
		ValidationResult Validate(CustomerModel entity);

		Task<ValidationResult> ValidateAsync(CustomerModel entity);
		void CreateMode();

		void UpdateMode();

		void DeleteMode();
	}
}

/*<Codenesium>
    <Hash>0e4750df202eaa593fe3f9793fcb6b1f</Hash>
</Codenesium>*/