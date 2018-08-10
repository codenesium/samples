using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiDeploymentHistoryRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDeploymentHistoryRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiDeploymentHistoryRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>f59f2a32dc54df000000db50ad1700f1</Hash>
</Codenesium>*/