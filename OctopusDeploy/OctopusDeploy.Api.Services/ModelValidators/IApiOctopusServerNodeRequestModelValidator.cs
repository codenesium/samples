using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiOctopusServerNodeRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiOctopusServerNodeRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiOctopusServerNodeRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>5424c237bfe8cf7f63f63be039bdcaa8</Hash>
</Codenesium>*/