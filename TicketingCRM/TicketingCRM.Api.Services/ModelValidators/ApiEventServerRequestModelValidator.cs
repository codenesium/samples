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
	public class ApiEventServerRequestModelValidator : AbstractValidator<ApiEventServerRequestModel>, IApiEventServerRequestModelValidator
	{
		private int existingRecordId;

		protected IEventRepository EventRepository { get; private set; }

		public ApiEventServerRequestModelValidator(IEventRepository eventRepository)
		{
			this.EventRepository = eventRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiEventServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiEventServerRequestModel model)
		{
			this.Address1Rules();
			this.Address2Rules();
			this.CityIdRules();
			this.DateRules();
			this.DescriptionRules();
			this.EndDateRules();
			this.FacebookRules();
			this.NameRules();
			this.StartDateRules();
			this.WebsiteRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiEventServerRequestModel model)
		{
			this.Address1Rules();
			this.Address2Rules();
			this.CityIdRules();
			this.DateRules();
			this.DescriptionRules();
			this.EndDateRules();
			this.FacebookRules();
			this.NameRules();
			this.StartDateRules();
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

		public virtual void CityIdRules()
		{
			this.RuleFor(x => x.CityId).MustAsync(this.BeValidCityByCityId).When(x => !x?.CityId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void DateRules()
		{
		}

		public virtual void DescriptionRules()
		{
			this.RuleFor(x => x.Description).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Description).Length(0, 2147483647).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void EndDateRules()
		{
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

		public virtual void StartDateRules()
		{
		}

		public virtual void WebsiteRules()
		{
			this.RuleFor(x => x.Website).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Website).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		protected async Task<bool> BeValidCityByCityId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.EventRepository.CityByCityId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>f23d7c0783be5e6a9a7935d6024811b1</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/