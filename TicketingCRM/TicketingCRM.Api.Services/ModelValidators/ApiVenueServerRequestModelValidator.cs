using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public class ApiVenueServerRequestModelValidator : AbstractValidator<ApiVenueServerRequestModel>, IApiVenueServerRequestModelValidator
	{
		private int existingRecordId;

		protected IVenueRepository VenueRepository { get; private set; }

		public ApiVenueServerRequestModelValidator(IVenueRepository venueRepository)
		{
			this.VenueRepository = venueRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiVenueServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiVenueServerRequestModel model)
		{
			this.Address1Rules();
			this.Address2Rules();
			this.AdminIdRules();
			this.EmailRules();
			this.FacebookRules();
			this.NameRules();
			this.PhoneRules();
			this.ProvinceIdRules();
			this.WebsiteRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiVenueServerRequestModel model)
		{
			this.Address1Rules();
			this.Address2Rules();
			this.AdminIdRules();
			this.EmailRules();
			this.FacebookRules();
			this.NameRules();
			this.PhoneRules();
			this.ProvinceIdRules();
			this.WebsiteRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}

		public virtual void Address1Rules()
		{
			this.RuleFor(x => x.Address1).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Address1).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void Address2Rules()
		{
			this.RuleFor(x => x.Address2).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Address2).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void AdminIdRules()
		{
			this.RuleFor(x => x.AdminId).MustAsync(this.BeValidAdminByAdminId).When(x => !x?.AdminId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void EmailRules()
		{
			this.RuleFor(x => x.Email).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Email).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void FacebookRules()
		{
			this.RuleFor(x => x.Facebook).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Facebook).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void PhoneRules()
		{
			this.RuleFor(x => x.Phone).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Phone).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void ProvinceIdRules()
		{
			this.RuleFor(x => x.ProvinceId).MustAsync(this.BeValidProvinceByProvinceId).When(x => !x?.ProvinceId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void WebsiteRules()
		{
			this.RuleFor(x => x.Website).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Website).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		protected async Task<bool> BeValidAdminByAdminId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.VenueRepository.AdminByAdminId(id);

			return record != null;
		}

		protected async Task<bool> BeValidProvinceByProvinceId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.VenueRepository.ProvinceByProvinceId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>b7b8774076e5087acd9726d9a96c9b04</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/