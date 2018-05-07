using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IAddressTypeModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(AddressTypeModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, AddressTypeModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>620d5c29cc1d50a7c9516947ef82b645</Hash>
</Codenesium>*/