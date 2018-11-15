using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiIllustrationServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiIllustrationServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiIllustrationServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>4d3cbc123c4a120ab3ba39f6b3589ffd</Hash>
</Codenesium>*/