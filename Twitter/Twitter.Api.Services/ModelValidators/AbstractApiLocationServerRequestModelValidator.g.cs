using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractApiLocationServerRequestModelValidator : AbstractValidator<ApiLocationServerRequestModel>
	{
		private int existingRecordId;

		protected ILocationRepository LocationRepository { get; private set; }

		public AbstractApiLocationServerRequestModelValidator(ILocationRepository locationRepository)
		{
			this.LocationRepository = locationRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiLocationServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void GpsLatRules()
		{
		}

		public virtual void GpsLongRules()
		{
		}

		public virtual void LocationNameRules()
		{
			this.RuleFor(x => x.LocationName).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.LocationName).Length(0, 64).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>57ce8205c0b2d706069daa13fef5ea29</Hash>
</Codenesium>*/