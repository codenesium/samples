using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiIllustrationServerRequestModelValidator : AbstractValidator<ApiIllustrationServerRequestModel>
	{
		private int existingRecordId;

		private IIllustrationRepository illustrationRepository;

		public AbstractApiIllustrationServerRequestModelValidator(IIllustrationRepository illustrationRepository)
		{
			this.illustrationRepository = illustrationRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiIllustrationServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void DiagramRules()
		{
		}

		public virtual void ModifiedDateRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>2dc064f715d4c0837f2c807a3f06aeaf</Hash>
</Codenesium>*/