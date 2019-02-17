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
	public abstract class AbstractApiTicketStatusServerRequestModelValidator : AbstractValidator<ApiTicketStatusServerRequestModel>
	{
		private int existingRecordId;

		protected ITicketStatusRepository TicketStatusRepository { get; private set; }

		public AbstractApiTicketStatusServerRequestModelValidator(ITicketStatusRepository ticketStatusRepository)
		{
			this.TicketStatusRepository = ticketStatusRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTicketStatusServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>c1f5cdd5be9a88712aa86b5237910963</Hash>
</Codenesium>*/