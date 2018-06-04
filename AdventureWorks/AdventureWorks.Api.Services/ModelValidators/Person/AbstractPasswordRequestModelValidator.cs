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
	public abstract class AbstractApiPasswordRequestModelValidator: AbstractValidator<ApiPasswordRequestModel>
	{
		private int existingRecordId;

		public new ValidationResult Validate(ApiPasswordRequestModel model, int id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiPasswordRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await base.ValidateAsync(model);
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void PasswordHashRules()
		{
			this.RuleFor(x => x.PasswordHash).NotNull();
			this.RuleFor(x => x.PasswordHash).Length(0, 128);
		}

		public virtual void PasswordSaltRules()
		{
			this.RuleFor(x => x.PasswordSalt).NotNull();
			this.RuleFor(x => x.PasswordSalt).Length(0, 10);
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>389235f7d30a89573e78423801491773</Hash>
</Codenesium>*/