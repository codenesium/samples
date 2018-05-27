using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiAddressTypeRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiAddressTypeRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiAddressTypeRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>81e8d2fd4505ec383d505c02ca58a69b</Hash>
</Codenesium>*/