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
    <Hash>b9e0752b2eaaa3c05ed37edca2c20676</Hash>
</Codenesium>*/