using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiAddressTypeModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiAddressTypeModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiAddressTypeModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>71a8bd1908b042e0b8d88dc7f714579b</Hash>
</Codenesium>*/