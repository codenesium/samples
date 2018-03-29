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

		void PatchMode();
	}
}

/*<Codenesium>
    <Hash>2f52b2faa2626daa3d3b2971ae904cb2</Hash>
</Codenesium>*/