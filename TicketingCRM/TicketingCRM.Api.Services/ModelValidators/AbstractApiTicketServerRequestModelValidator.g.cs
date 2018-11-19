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
	public abstract class AbstractApiTicketServerRequestModelValidator : AbstractValidator<ApiTicketServerRequestModel>
	{
		private int existingRecordId;

		private ITicketRepository ticketRepository;

		public AbstractApiTicketServerRequestModelValidator(ITicketRepository ticketRepository)
		{
			this.ticketRepository = ticketRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTicketServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void PublicIdRules()
		{
			this.RuleFor(x => x.PublicId).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.PublicId).Length(0, 8).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void TicketStatusIdRules()
		{
			this.RuleFor(x => x.TicketStatusId).MustAsync(this.BeValidTicketStatuByTicketStatusId).When(x => !x?.TicketStatusId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		private async Task<bool> BeValidTicketStatuByTicketStatusId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.ticketRepository.TicketStatuByTicketStatusId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>357793e200c17d571415b317c73adc52</Hash>
</Codenesium>*/