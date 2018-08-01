using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractApiCertificateRequestModelValidator : AbstractValidator<ApiCertificateRequestModel>
	{
		private string existingRecordId;

		private ICertificateRepository certificateRepository;

		public AbstractApiCertificateRequestModelValidator(ICertificateRepository certificateRepository)
		{
			this.certificateRepository = certificateRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiCertificateRequestModel model, string id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ArchivedRules()
		{
		}

		public virtual void CreatedRules()
		{
		}

		public virtual void DataVersionRules()
		{
		}

		public virtual void EnvironmentIdsRules()
		{
		}

		public virtual void JSONRules()
		{
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).Length(0, 200);
		}

		public virtual void NotAfterRules()
		{
		}

		public virtual void SubjectRules()
		{
		}

		public virtual void TenantIdsRules()
		{
		}

		public virtual void TenantTagsRules()
		{
		}

		public virtual void ThumbprintRules()
		{
			this.RuleFor(x => x.Thumbprint).Length(0, 128);
		}
	}
}

/*<Codenesium>
    <Hash>b7249a9231fa2395aade0105423f3a8b</Hash>
</Codenesium>*/