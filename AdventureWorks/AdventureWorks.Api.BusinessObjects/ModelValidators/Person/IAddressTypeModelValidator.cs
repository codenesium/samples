using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IAddressTypeModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(AddressTypeModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, AddressTypeModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>0f4da4cf45db1235d1cf7bae5a82ccdc</Hash>
</Codenesium>*/