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
	public class ApiTicketServerRequestModelValidator : AbstractValidator<ApiTicketServerRequestModel>, IApiTicketServerRequestModelValidator
	{
		private int existingRecordId;

		protected ITicketRepository TicketRepository { get; private set; }

		public ApiTicketServerRequestModelValidator(ITicketRepository ticketRepository)
		{
			this.TicketRepository = ticketRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTicketServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTicketServerRequestModel model)
		{
			this.PublicIdRules();
			this.TicketStatusIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTicketServerRequestModel model)
		{
			this.PublicIdRules();
			this.TicketStatusIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}

		public virtual void PublicIdRules()
		{
			this.RuleFor(x => x.PublicId).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.PublicId).Length(0, 8).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void TicketStatusIdRules()
		{
			this.RuleFor(x => x.TicketStatusId).MustAsync(this.BeValidTicketStatusByTicketStatusId).When(x => !x?.TicketStatusId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidTicketStatusByTicketStatusId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.TicketRepository.TicketStatusByTicketStatusId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>da179d123c95040c2c18bce1dbef45fb</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/