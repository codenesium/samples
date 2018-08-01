using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public interface IApiCertificateRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCertificateRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(string id, ApiCertificateRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>de14ed583b6f766f9dee6e7f841dd021</Hash>
</Codenesium>*/