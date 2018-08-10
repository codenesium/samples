using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiIllustrationRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiIllustrationRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiIllustrationRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>1a1e886c3603ed1445dc4cabf4a490d5</Hash>
</Codenesium>*/