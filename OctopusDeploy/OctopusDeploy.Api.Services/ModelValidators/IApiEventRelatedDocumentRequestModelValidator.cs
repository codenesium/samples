using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IApiEventRelatedDocumentRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiEventRelatedDocumentRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiEventRelatedDocumentRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>a6740ef9727a1267eda71a94097d6524</Hash>
</Codenesium>*/