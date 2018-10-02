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
	public abstract class AbstractApiLocationRequestModelValidator : AbstractValidator<ApiLocationRequestModel>
	{
		private int existingRecordId;

		private ILocationRepository locationRepository;

		public AbstractApiLocationRequestModelValidator(ILocationRepository locationRepository)
		{
			this.locationRepository = locationRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiLocationRequestModel model, int id)
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
    <Hash>96a8fe35270bdd6276448cdf07d598c6</Hash>
</Codenesium>*/