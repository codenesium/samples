using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractApiLocationServerRequestModelValidator : AbstractValidator<ApiLocationServerRequestModel>
	{
		private int existingRecordId;

		private ILocationRepository locationRepository;

		public AbstractApiLocationServerRequestModelValidator(ILocationRepository locationRepository)
		{
			this.locationRepository = locationRepository;
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
			this.RuleFor(x => x.LocationName).NotNull();
			this.RuleFor(x => x.LocationName).Length(0, 64);
		}
	}
}

/*<Codenesium>
    <Hash>e86755ea2cf7db9c6846aad7dcef9464</Hash>
</Codenesium>*/