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
	public abstract class AbstractApiStoreRequestModelValidator: AbstractValidator<ApiStoreRequestModel>
	{
		private int existingRecordId;

		public new ValidationResult Validate(ApiStoreRequestModel model, int id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiStoreRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await base.ValidateAsync(model);
		}

		public ISalesPersonRepository SalesPersonRepository { get; set; }
		public virtual void DemographicsRules()
		{                       }

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void SalesPersonIDRules()
		{
			this.RuleFor(x => x.SalesPersonID).MustAsync(this.BeValidSalesPerson).When(x => x ?.SalesPersonID != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidSalesPerson(Nullable<int> id,  CancellationToken cancellationToken)
		{
			var record = await this.SalesPersonRepository.Get(id.GetValueOrDefault());

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>40ab78b5f4bfd81c25f8de841ef6c0cc</Hash>
</Codenesium>*/