using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public abstract class AbstractApiCallTypeServerRequestModelValidator : AbstractValidator<ApiCallTypeServerRequestModel>
	{
		private int existingRecordId;

		protected ICallTypeRepository CallTypeRepository { get; private set; }

		public AbstractApiCallTypeServerRequestModelValidator(ICallTypeRepository callTypeRepository)
		{
			this.CallTypeRepository = callTypeRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiCallTypeServerRequestModel model, int id)
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
    <Hash>a499fd4ce71f41b379994822da76ee4c</Hash>
</Codenesium>*/