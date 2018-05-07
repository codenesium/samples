using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface ICustomerModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(CustomerModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, CustomerModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>96e92d29b6dc35fe754b05b379e9b198</Hash>
</Codenesium>*/