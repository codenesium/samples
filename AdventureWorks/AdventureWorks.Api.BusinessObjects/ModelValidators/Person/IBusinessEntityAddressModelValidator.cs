using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBusinessEntityAddressModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(BusinessEntityAddressModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, BusinessEntityAddressModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>bf9dd5fe1be0210497591aa62a4ad1d6</Hash>
</Codenesium>*/