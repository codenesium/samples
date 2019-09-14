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
	public class ApiLocationServerRequestModelValidator : AbstractValidator<ApiLocationServerRequestModel>, IApiLocationServerRequestModelValidator
	{
		private int existingRecordId;

		protected ILocationRepository LocationRepository { get; private set; }

		public ApiLocationServerRequestModelValidator(ILocationRepository locationRepository)
		{
			this.LocationRepository = locationRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiLocationServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiLocationServerRequestModel model)
		{
			this.GpsLatRules();
			this.GpsLongRules();
			this.LocationNameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiLocationServerRequestModel model)
		{
			this.GpsLatRules();
			this.GpsLongRules();
			this.LocationNameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
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
    <Hash>7d519a64bd81a823d4e45cebc5178225</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/