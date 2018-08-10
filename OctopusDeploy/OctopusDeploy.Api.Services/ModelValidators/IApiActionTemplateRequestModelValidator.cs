using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiActionTemplateRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiActionTemplateRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiActionTemplateRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>423db18fb0177b1434fad1aeef58ec56</Hash>
</Codenesium>*/