using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiScrapReasonServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiScrapReasonServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(short id, ApiScrapReasonServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(short id);
	}
}

/*<Codenesium>
    <Hash>2ab80df7b4ab447e16325403fcb310fa</Hash>
</Codenesium>*/