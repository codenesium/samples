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
	public abstract class AbstractApiContactTypeRequestModelValidator : AbstractValidator<ApiContactTypeRequestModel>
	{
		private int existingRecordId;

		private IContactTypeRepository contactTypeRepository;

		public AbstractApiContactTypeRequestModelValidator(IContactTypeRepository contactTypeRepository)
		{
			this.contactTypeRepository = contactTypeRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiContactTypeRequestModel model, int id)
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
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiContactTypeRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		private async Task<bool> BeUniqueByName(ApiContactTypeRequestModel model,  CancellationToken cancellationToken)
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
    <Hash>061f758837c875abcb4f386d2a6cfc7f</Hash>
</Codenesium>*/