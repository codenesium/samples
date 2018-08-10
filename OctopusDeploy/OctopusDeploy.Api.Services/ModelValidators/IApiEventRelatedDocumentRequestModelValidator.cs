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
    <Hash>ab97a809354af7c53f23da8d13dba5e7</Hash>
</Codenesium>*/