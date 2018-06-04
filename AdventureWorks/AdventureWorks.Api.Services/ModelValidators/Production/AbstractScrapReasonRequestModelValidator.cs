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
	public abstract class AbstractApiScrapReasonRequestModelValidator: AbstractValidator<ApiScrapReasonRequestModel>
	{
		private short existingRecordId;

		public new ValidationResult Validate(ApiScrapReasonRequestModel model, short id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiScrapReasonRequestModel model, short id)
		{
			this.existingRecordId = id;
			return await base.ValidateAsync(model);
		}

		public IScrapReasonRepository ScrapReasonRepository { get; set; }
		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiScrapReasonRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		private async Task<bool> BeUniqueGetName(ApiScrapReasonRequestModel model,  CancellationToken cancellationToken)
		{
			ScrapReason record = await this.ScrapReasonRepository.GetName(model.Name);

			if(record == null || record.ScrapReasonID == this.existingRecordId)
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
    <Hash>86d5d483895364e6cd3d648428ebaa16</Hash>
</Codenesium>*/