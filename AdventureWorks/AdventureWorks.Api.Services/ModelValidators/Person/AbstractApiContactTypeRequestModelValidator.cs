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
	public abstract class AbstractApiContactTypeRequestModelValidator: AbstractValidator<ApiContactTypeRequestModel>
	{
		private int existingRecordId;

		public new ValidationResult Validate(ApiContactTypeRequestModel model, int id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiContactTypeRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await base.ValidateAsync(model);
		}

		public IContactTypeRepository ContactTypeRepository { get; set; }
		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiContactTypeRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		private async Task<bool> BeUniqueGetName(ApiContactTypeRequestModel model,  CancellationToken cancellationToken)
		{
			ContactType record = await this.ContactTypeRepository.GetName(model.Name);

			if(record == null || record.ContactTypeID == this.existingRecordId)
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
    <Hash>0bda9a6d404e45a1213087c5757082cc</Hash>
</Codenesium>*/