using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiProjectGroupRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProjectGroupRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiProjectGroupRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>898324dfc4e8e5c32fc6e73dab01e15c</Hash>
</Codenesium>*/