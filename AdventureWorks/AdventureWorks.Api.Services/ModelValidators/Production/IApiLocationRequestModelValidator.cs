using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiLocationRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLocationRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(short id, ApiLocationRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(short id);
	}
}

/*<Codenesium>
    <Hash>ddf8eac70c45480ceebc9defd547e1b2</Hash>
</Codenesium>*/