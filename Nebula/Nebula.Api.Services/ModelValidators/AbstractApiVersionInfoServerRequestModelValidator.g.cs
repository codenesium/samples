using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
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
			this.RuleFor(x => x.Description).Length(0, 1024).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>4200a1906ee2ff33ec73a731037339d1</Hash>
</Codenesium>*/