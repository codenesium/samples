using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiFeedRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiFeedRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiFeedRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>53d86db3e36a2121c11d8c25fdab5625</Hash>
</Codenesium>*/