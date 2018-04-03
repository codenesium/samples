using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractJobCandidateModelValidator: AbstractValidator<JobCandidateModel>
	{
		public new ValidationResult Validate(JobCandidateModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(JobCandidateModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void BusinessEntityIDRules()
		{                       }

		public virtual void ResumeRules()
		{                       }

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>be9d345c1b9827c276f36f1a3a812f92</Hash>
</Codenesium>*/