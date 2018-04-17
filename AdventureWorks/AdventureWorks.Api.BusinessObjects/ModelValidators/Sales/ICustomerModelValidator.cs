using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface ICustomerModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(CustomerModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, CustomerModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>658a9a6b1a1ca4ebe8597872cc6e0e37</Hash>
</Codenesium>*/