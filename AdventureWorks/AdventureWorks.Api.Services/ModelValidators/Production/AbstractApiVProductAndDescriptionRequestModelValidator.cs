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
	public abstract class AbstractApiVProductAndDescriptionRequestModelValidator : AbstractValidator<ApiVProductAndDescriptionRequestModel>
	{
		private string existingRecordId;

		private IVProductAndDescriptionRepository vProductAndDescriptionRepository;

		public AbstractApiVProductAndDescriptionRequestModelValidator(IVProductAndDescriptionRepository vProductAndDescriptionRepository)
		{
			this.vProductAndDescriptionRepository = vProductAndDescriptionRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiVProductAndDescriptionRequestModel model, string id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void DescriptionRules()
		{
			this.RuleFor(x => x.Description).NotNull();
			this.RuleFor(x => x.Description).Length(0, 400);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void ProductIDRules()
		{
		}

		public virtual void ProductModelRules()
		{
			this.RuleFor(x => x.ProductModel).NotNull();
			this.RuleFor(x => x.ProductModel).Length(0, 50);
		}
	}
}

/*<Codenesium>
    <Hash>6bb676be9122650a3d0fd96e0e89ab4e</Hash>
</Codenesium>*/