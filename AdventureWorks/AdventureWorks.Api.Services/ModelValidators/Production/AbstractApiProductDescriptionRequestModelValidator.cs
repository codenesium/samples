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
	public abstract class AbstractApiProductDescriptionRequestModelValidator : AbstractValidator<ApiProductDescriptionRequestModel>
	{
		private int existingRecordId;

		private IProductDescriptionRepository productDescriptionRepository;

		public AbstractApiProductDescriptionRequestModelValidator(IProductDescriptionRepository productDescriptionRepository)
		{
			this.productDescriptionRepository = productDescriptionRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiProductDescriptionRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void DescriptionRules()
		{
			this.RuleFor(x => x.Description).NotNull();
			this.RuleFor(x => x.Description).Length(0, 400);
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void RowguidRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>044f802c55a1c069ec7c0f4e44304629</Hash>
</Codenesium>*/