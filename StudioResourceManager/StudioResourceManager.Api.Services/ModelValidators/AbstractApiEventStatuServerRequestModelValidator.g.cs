using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractApiEventStatuServerRequestModelValidator : AbstractValidator<ApiEventStatuServerRequestModel>
	{
		private int existingRecordId;

		protected IEventStatuRepository EventStatuRepository { get; private set; }

		public AbstractApiEventStatuServerRequestModelValidator(IEventStatuRepository eventStatuRepository)
		{
			this.EventStatuRepository = eventStatuRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiEventStatuServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>69b6547d48e0a97918973830768eb995</Hash>
</Codenesium>*/