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
	public abstract class AbstractApiIllustrationServerRequestModelValidator : AbstractValidator<ApiIllustrationServerRequestModel>
	{
		private int existingRecordId;

		protected IIllustrationRepository IllustrationRepository { get; private set; }

		public AbstractApiIllustrationServerRequestModelValidator(IIllustrationRepository illustrationRepository)
		{
			this.IllustrationRepository = illustrationRepository;
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
    <Hash>81ebfc65a5e7b805578f777247067c18</Hash>
</Codenesium>*/