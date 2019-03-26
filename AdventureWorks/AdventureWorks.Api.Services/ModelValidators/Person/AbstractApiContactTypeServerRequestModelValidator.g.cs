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
	public abstract class AbstractApiContactTypeServerRequestModelValidator : AbstractValidator<ApiContactTypeServerRequestModel>
	{
		private int existingRecordId;

		protected IContactTypeRepository ContactTypeRepository { get; private set; }

		public AbstractApiContactTypeServerRequestModelValidator(IContactTypeRepository contactTypeRepository)
		{
			this.ContactTypeRepository = contactTypeRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiContactTypeServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => (!x?.Name.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiContactTypeServerRequestModel.Name)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
			this.RuleFor(x => x.Name).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		protected async Task<bool> BeUniqueByName(ApiContactTypeServerRequestModel model,  CancellationToken cancellationToken)
		{
			ContactType record = await this.ContactTypeRepository.ByName(model.Name);

			if (record == null || (this.existingRecordId != default(int) && record.ContactTypeID == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}

/*<Codenesium>
    <Hash>17e080440b66903e581bba77c99fc9ae</Hash>
</Codenesium>*/