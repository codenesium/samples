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

		protected ITicketRepository TicketRepository { get; private set; }

		public AbstractApiTicketServerRequestModelValidator(ITicketRepository ticketRepository)
		{
			this.TicketRepository = ticketRepository;
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

		protected async Task<bool> BeValidTicketStatuByTicketStatusId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.TicketRepository.TicketStatuByTicketStatusId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>a87cf8acef6793ffd69bded06d451578</Hash>
</Codenesium>*/