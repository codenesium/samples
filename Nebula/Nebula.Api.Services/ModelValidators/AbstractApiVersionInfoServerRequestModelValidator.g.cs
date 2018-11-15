using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using NebulaNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractApiVersionInfoServerRequestModelValidator : AbstractValidator<ApiVersionInfoServerRequestModel>
	{
		private long existingRecordId;

		private IVersionInfoRepository versionInfoRepository;

		public AbstractApiVersionInfoServerRequestModelValidator(IVersionInfoRepository versionInfoRepository)
		{
			this.versionInfoRepository = versionInfoRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiVersionInfoServerRequestModel model, long id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void AppliedOnRules()
		{
		}

		public virtual void DescriptionRules()
		{
			this.RuleFor(x => x.Description).Length(0, 1024);
		}
	}
}

/*<Codenesium>
    <Hash>891b8b40e323fef73dabd163495488f5</Hash>
</Codenesium>*/