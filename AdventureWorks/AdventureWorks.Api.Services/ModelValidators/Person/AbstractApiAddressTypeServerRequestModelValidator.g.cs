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
	public abstract class AbstractApiAddressTypeServerRequestModelValidator : AbstractValidator<ApiAddressTypeServerRequestModel>
	{
		private int existingRecordId;

		protected IAddressTypeRepository AddressTypeRepository { get; private set; }

		public AbstractApiAddressTypeServerRequestModelValidator(IAddressTypeRepository addressTypeRepository)
		{
			this.AddressTypeRepository = addressTypeRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiAddressTypeServerRequestModel model, int id)
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
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => (!x?.Name.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiAddressTypeServerRequestModel.Name)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
			this.RuleFor(x => x.Name).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByRowguid).When(x => (!x?.Rowguid.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiAddressTypeServerRequestModel.Rowguid)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
		}

		protected async Task<bool> BeUniqueByName(ApiAddressTypeServerRequestModel model,  CancellationToken cancellationToken)
		{
			AddressType record = await this.AddressTypeRepository.ByName(model.Name);

			if (record == null || (this.existingRecordId != default(int) && record.AddressTypeID == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		protected async Task<bool> BeUniqueByRowguid(ApiAddressTypeServerRequestModel model,  CancellationToken cancellationToken)
		{
			AddressType record = await this.AddressTypeRepository.ByRowguid(model.Rowguid);

			if (record == null || (this.existingRecordId != default(int) && record.AddressTypeID == this.existingRecordId))
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
    <Hash>7ae47daf575a47c80c5661be8977c085</Hash>
</Codenesium>*/