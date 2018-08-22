using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IApiCertificateRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCertificateRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiCertificateRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>868e9756b3b223ce8e55812699ddba23</Hash>
</Codenesium>*/