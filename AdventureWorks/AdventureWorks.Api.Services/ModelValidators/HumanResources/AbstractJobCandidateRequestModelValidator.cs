using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services

{
	public abstract class AbstractApiJobCandidateRequestModelValidator: AbstractValidator<ApiJobCandidateRequestModel>
	{
		private int existingRecordId;

		public new ValidationResult Validate(ApiJobCandidateRequestModel model, int id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiJobCandidateRequestModel model, int id)
		{
			this.existingRecordId = id;
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
    <Hash>c19b4b8dc897b3747725e7bce9a24d0b</Hash>
</Codenesium>*/