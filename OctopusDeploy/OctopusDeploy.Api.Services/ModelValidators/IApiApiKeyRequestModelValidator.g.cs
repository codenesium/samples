using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiApiKeyRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiApiKeyRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiApiKeyRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>4a587db2dcc68f321395f2c9f007efa2</Hash>
</Codenesium>*/