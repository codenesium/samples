using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiBusinessEntityAddressRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiBusinessEntityAddressRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiBusinessEntityAddressRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>dc958107a84310e58222824efe2c5cad</Hash>
</Codenesium>*/