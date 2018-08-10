using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiPersonRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPersonRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPersonRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>06657d6f4d1c9c34b0a69bf1501d020e</Hash>
</Codenesium>*/