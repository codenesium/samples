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
	public abstract class AbstractApiProductModelIllustrationRequestModelValidator: AbstractValidator<ApiProductModelIllustrationRequestModel>
	{
		private int existingRecordId;

		public new ValidationResult Validate(ApiProductModelIllustrationRequestModel model, int id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiProductModelIllustrationRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await base.ValidateAsync(model);
		}

		public virtual void IllustrationIDRules()
		{
			this.RuleFor(x => x.IllustrationID).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>b76453da631e9bdfffa1060f790fdd5b</Hash>
</Codenesium>*/