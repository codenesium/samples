using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiPersonPhoneRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPersonPhoneRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPersonPhoneRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>da7b8d4cc02260100d0f0faff6d6436f</Hash>
</Codenesium>*/