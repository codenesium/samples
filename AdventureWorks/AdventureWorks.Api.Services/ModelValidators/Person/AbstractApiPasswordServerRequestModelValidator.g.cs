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
	public abstract class AbstractApiPasswordServerRequestModelValidator : AbstractValidator<ApiPasswordServerRequestModel>
	{
		private int existingRecordId;

		protected IPasswordRepository PasswordRepository { get; private set; }

		public AbstractApiPasswordServerRequestModelValidator(IPasswordRepository passwordRepository)
		{
			this.PasswordRepository = passwordRepository;
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
			this.RuleFor(x => x.PasswordHash).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.PasswordHash).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void PasswordSaltRules()
		{
			this.RuleFor(x => x.PasswordSalt).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.PasswordSalt).Length(0, 10).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void RowguidRules()
		{
		}

		protected async Task<bool> BeValidPersonByBusinessEntityID(int id,  CancellationToken cancellationToken)
		{
			var record = await this.PasswordRepository.PersonByBusinessEntityID(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>74df0b720a234749a5d5b6674cc55aec</Hash>
</Codenesium>*/