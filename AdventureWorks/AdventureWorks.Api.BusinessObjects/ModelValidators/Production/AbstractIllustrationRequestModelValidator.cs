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
	public abstract class AbstractApiIllustrationRequestModelValidator: AbstractValidator<ApiIllustrationRequestModel>
	{
		public new ValidationResult Validate(ApiIllustrationRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiIllustrationRequestModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void DiagramRules()
		{                       }

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>093585375ab2652ee6525652b162ccfe</Hash>
</Codenesium>*/