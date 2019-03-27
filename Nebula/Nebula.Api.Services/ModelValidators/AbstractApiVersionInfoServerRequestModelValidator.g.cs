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

		protected IVersionInfoRepository VersionInfoRepository { get; private set; }

		public AbstractApiVersionInfoServerRequestModelValidator(IVersionInfoRepository versionInfoRepository)
		{
			this.VersionInfoRepository = versionInfoRepository;
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
    <Hash>d0917c54c412065b0a31b1c3bbbe4ca8</Hash>
</Codenesium>*/