using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiJobCandidateRequestModelValidator: AbstractValidator<ApiJobCandidateRequestModel>
	{
		public new ValidationResult Validate(ApiJobCandidateRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiJobCandidateRequestModel model)
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
    <Hash>fe01f0afc48f49e1a25a84470dcfc3af</Hash>
</Codenesium>*/