using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiStateProvinceRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiStateProvinceRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiStateProvinceRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>15ea9f229db9b0c02db246441968cebb</Hash>
</Codenesium>*/