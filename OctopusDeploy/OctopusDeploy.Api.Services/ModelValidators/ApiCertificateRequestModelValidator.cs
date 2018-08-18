using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public class ApiCertificateRequestModelValidator : AbstractApiCertificateRequestModelValidator, IApiCertificateRequestModelValidator
	{
		public ApiCertificateRequestModelValidator(ICertificateRepository certificateRepository)
			: base(certificateRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiCertificateRequestModel model)
		{
			this.ArchivedRules();
			this.CreatedRules();
			this.DataVersionRules();
			this.EnvironmentIdsRules();
			this.JSONRules();
			this.NameRules();
			this.NotAfterRules();
			this.SubjectRules();
			this.TenantIdsRules();
			this.TenantTagsRules();
			this.ThumbprintRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiCertificateRequestModel model)
		{
			this.ArchivedRules();
			this.CreatedRules();
			this.DataVersionRules();
			this.EnvironmentIdsRules();
			this.JSONRules();
			this.NameRules();
			this.NotAfterRules();
			this.SubjectRules();
			this.TenantIdsRules();
			this.TenantTagsRules();
			this.ThumbprintRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(string id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>55f38d5ddedcd66ba9bf2acf01e6f9e6</Hash>
</Codenesium>*/