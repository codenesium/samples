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
	public abstract class AbstractApiBusinessEntityContactRequestModelValidator: AbstractValidator<ApiBusinessEntityContactRequestModel>
	{
		private int existingRecordId;

		public new ValidationResult Validate(ApiBusinessEntityContactRequestModel model, int id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiBusinessEntityContactRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await base.ValidateAsync(model);
		}

		public virtual void ContactTypeIDRules()
		{
			this.RuleFor(x => x.ContactTypeID).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void PersonIDRules()
		{
			this.RuleFor(x => x.PersonID).NotNull();
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>f6ebd73ce0fdd0821b519d673544b121</Hash>
</Codenesium>*/