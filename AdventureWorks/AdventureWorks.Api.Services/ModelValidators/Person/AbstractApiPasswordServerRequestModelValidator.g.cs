using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiPasswordServerRequestModelValidator : AbstractValidator<ApiPasswordServerRequestModel>
	{
		private int existingRecordId;

		private IPasswordRepository passwordRepository;

		public AbstractApiPasswordServerRequestModelValidator(IPasswordRepository passwordRepository)
		{
			this.passwordRepository = passwordRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPasswordServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ModifiedDateRules()
		{
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
		}
	}
}

/*<Codenesium>
    <Hash>fa49c4c93403bf2e786723262f69202c</Hash>
</Codenesium>*/