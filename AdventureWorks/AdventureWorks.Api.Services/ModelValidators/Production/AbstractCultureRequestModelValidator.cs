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
	public abstract class AbstractApiCultureRequestModelValidator: AbstractValidator<ApiCultureRequestModel>
	{
		private string existingRecordId;

		public new ValidationResult Validate(ApiCultureRequestModel model, string id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiCultureRequestModel model, string id)
		{
			this.existingRecordId = id;
			return await base.ValidateAsync(model);
		}

		public ICultureRepository CultureRepository { get; set; }
		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiCultureRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		private async Task<bool> BeUniqueGetName(ApiCultureRequestModel model,  CancellationToken cancellationToken)
		{
			Culture record = await this.CultureRepository.GetName(model.Name);

			if(record == null || record.CultureID == this.existingRecordId)
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
    <Hash>4ca4dae666ac9940e0eec718497412b5</Hash>
</Codenesium>*/