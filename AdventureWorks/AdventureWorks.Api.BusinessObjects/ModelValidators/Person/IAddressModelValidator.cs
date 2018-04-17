using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IAddressModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(AddressModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, AddressModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>30d25045a607dd8d6a5324f2195ec1f2</Hash>
</Codenesium>*/