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

		private IAddressTypeRepository addressTypeRepository;

		public AbstractApiAddressTypeServerRequestModelValidator(IAddressTypeRepository addressTypeRepository)
		{
			this.addressTypeRepository = addressTypeRepository;
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
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => !x?.Name.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiAddressTypeServerRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByRowguid).When(x => !x?.Rowguid.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiAddressTypeServerRequestModel.Rowguid));
		}

		private async Task<bool> BeUniqueByName(ApiAddressTypeServerRequestModel model,  CancellationToken cancellationToken)
		{
			AddressType record = await this.addressTypeRepository.ByName(model.Name);

			if (record == null || (this.existingRecordId != default(int) && record.AddressTypeID == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private async Task<bool> BeUniqueByRowguid(ApiAddressTypeServerRequestModel model,  CancellationToken cancellationToken)
		{
			AddressType record = await this.addressTypeRepository.ByRowguid(model.Rowguid);

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
    <Hash>2652dcb3f5b4e0d933c21ac8df685f72</Hash>
</Codenesium>*/