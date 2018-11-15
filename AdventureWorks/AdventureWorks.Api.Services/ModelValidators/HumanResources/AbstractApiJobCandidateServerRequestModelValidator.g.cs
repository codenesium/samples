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
    <Hash>81e7b16377da5c748bf013cb92e1787b</Hash>
</Codenesium>*/