using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractApiVenueServerRequestModelValidator : AbstractValidator<ApiVenueServerRequestModel>
	{
		private int existingRecordId;

		private IVenueRepository venueRepository;

		public AbstractApiVenueServerRequestModelValidator(IVenueRepository venueRepository)
		{
			this.venueRepository = venueRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiVenueServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void Address1Rules()
		{
			this.RuleFor(x => x.Address1).NotNull();
			this.RuleFor(x => x.Address1).Length(0, 128);
		}

		public virtual void Address2Rules()
		{
			this.RuleFor(x => x.Address2).NotNull();
			this.RuleFor(x => x.Address2).Length(0, 128);
		}

		public virtual void AdminIdRules()
		{
			this.RuleFor(x => x.AdminId).MustAsync(this.BeValidAdminByAdminId).When(x => !x?.AdminId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
		}

		public virtual void EmailRules()
		{
			this.RuleFor(x => x.Email).NotNull();
			this.RuleFor(x => x.Email).Length(0, 128);
		}

		public virtual void FacebookRules()
		{
			this.RuleFor(x => x.Facebook).NotNull();
			this.RuleFor(x => x.Facebook).Length(0, 128);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 128);
		}

		public virtual void PhoneRules()
		{
			this.RuleFor(x => x.Phone).NotNull();
			this.RuleFor(x => x.Phone).Length(0, 128);
		}

		public virtual void ProvinceIdRules()
		{
			this.RuleFor(x => x.ProvinceId).MustAsync(this.BeValidProvinceByProvinceId).When(x => !x?.ProvinceId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
		}

		public virtual void WebsiteRules()
		{
			this.RuleFor(x => x.Website).NotNull();
			this.RuleFor(x => x.Website).Length(0, 128);
		}

		private async Task<bool> BeValidAdminByAdminId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.venueRepository.AdminByAdminId(id);

			return record != null;
		}

		private async Task<bool> BeValidProvinceByProvinceId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.venueRepository.ProvinceByProvinceId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>7f4a88962393737f9b1c8aeaffe11716</Hash>
</Codenesium>*/