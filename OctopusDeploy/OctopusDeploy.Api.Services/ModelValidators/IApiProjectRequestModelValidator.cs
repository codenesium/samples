using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IApiProjectRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProjectRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiProjectRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>0bd347e8ee70a1e6635f9e7d3b103d2f</Hash>
</Codenesium>*/