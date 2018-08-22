using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiEventRelatedDocumentRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiEventRelatedDocumentRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiEventRelatedDocumentRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>c26a00367c8325dcf38e063ceb961f4b</Hash>
</Codenesium>*/