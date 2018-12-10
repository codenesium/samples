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

		protected IJobCandidateRepository JobCandidateRepository { get; private set; }

		public AbstractApiJobCandidateServerRequestModelValidator(IJobCandidateRepository jobCandidateRepository)
		{
			this.JobCandidateRepository = jobCandidateRepository;
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
    <Hash>e795d00e1f44235ab6490aa5ec196b85</Hash>
</Codenesium>*/