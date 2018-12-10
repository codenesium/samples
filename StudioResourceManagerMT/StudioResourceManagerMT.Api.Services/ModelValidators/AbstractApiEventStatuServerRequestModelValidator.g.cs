using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>f4c7c4da32b6a72f3f66c61732bc8a12</Hash>
</Codenesium>*/