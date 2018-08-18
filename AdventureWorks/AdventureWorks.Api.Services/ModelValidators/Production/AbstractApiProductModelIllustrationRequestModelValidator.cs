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
	public abstract class AbstractApiProductModelIllustrationRequestModelValidator : AbstractValidator<ApiProductModelIllustrationRequestModel>
	{
		private int existingRecordId;

		private IProductModelIllustrationRepository productModelIllustrationRepository;

		public AbstractApiProductModelIllustrationRequestModelValidator(IProductModelIllustrationRepository productModelIllustrationRepository)
		{
			this.productModelIllustrationRepository = productModelIllustrationRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiProductModelIllustrationRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void IllustrationIDRules()
		{
		}

		public virtual void ModifiedDateRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>5be29151b8c9d2687f76601a1eb75a88</Hash>
</Codenesium>*/