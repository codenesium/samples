using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiLocationServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLocationServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(short id, ApiLocationServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(short id);
	}
}

/*<Codenesium>
    <Hash>e293cb7840baba51edfd015e0888ac98</Hash>
</Codenesium>*/