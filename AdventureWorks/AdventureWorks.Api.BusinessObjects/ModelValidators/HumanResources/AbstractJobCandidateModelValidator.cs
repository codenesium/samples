using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiJobCandidateModelValidator: AbstractValidator<ApiJobCandidateModel>
	{
		public new ValidationResult Validate(ApiJobCandidateModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiJobCandidateModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void BusinessEntityIDRules()
		{                       }

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void ResumeRules()
		{                       }
	}
}

/*<Codenesium>
    <Hash>d75861a3f85dd35eca37106a0fe173ae</Hash>
</Codenesium>*/