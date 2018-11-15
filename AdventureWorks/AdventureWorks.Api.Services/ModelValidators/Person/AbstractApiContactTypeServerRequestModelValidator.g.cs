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

		private IContactTypeRepository contactTypeRepository;

		public AbstractApiContactTypeServerRequestModelValidator(IContactTypeRepository contactTypeRepository)
		{
			this.contactTypeRepository = contactTypeRepository;
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
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => !x?.Name.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiContactTypeServerRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		private async Task<bool> BeUniqueByName(ApiContactTypeServerRequestModel model,  CancellationToken cancellationToken)
		{
			ContactType record = await this.contactTypeRepository.ByName(model.Name);

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
    <Hash>1b3d3d490aa40825ff06d8a5eba2a087</Hash>
</Codenesium>*/