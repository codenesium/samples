using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiPersonPhoneRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPersonPhoneRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPersonPhoneRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>0558023b3860f464b2c8c7f70a743e36</Hash>
</Codenesium>*/