using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>aa7f14439b1acdac33c775778dbab837</Hash>
</Codenesium>*/