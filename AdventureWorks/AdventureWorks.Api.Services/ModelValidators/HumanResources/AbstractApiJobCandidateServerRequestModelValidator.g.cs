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
			this.RuleFor(x => x.BusinessEntityID).MustAsync(this.BeValidEmployeeByBusinessEntityID).When(x => !x?.BusinessEntityID.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void ResumeRules()
		{
		}

		protected async Task<bool> BeValidEmployeeByBusinessEntityID(int? id,  CancellationToken cancellationToken)
		{
			var record = await this.JobCandidateRepository.EmployeeByBusinessEntityID(id.GetValueOrDefault());

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>b572798b79ca3478170aecf473a2cf60</Hash>
</Codenesium>*/