using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiJobCandidateServerRequestModelValidator : AbstractValidator<ApiJobCandidateServerRequestModel>
	{
		private int existingRecordId;

		private IJobCandidateRepository jobCandidateRepository;

		public AbstractApiJobCandidateServerRequestModelValidator(IJobCandidateRepository jobCandidateRepository)
		{
			this.jobCandidateRepository = jobCandidateRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiJobCandidateServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void BusinessEntityIDRules()
		{
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void ResumeRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>8927d1fb3659265a8195e8f4c919f0b7</Hash>
</Codenesium>*/