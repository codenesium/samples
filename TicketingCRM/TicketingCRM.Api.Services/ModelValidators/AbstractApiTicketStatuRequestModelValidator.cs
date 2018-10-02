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
	public abstract class AbstractApiTicketStatuRequestModelValidator : AbstractValidator<ApiTicketStatuRequestModel>
	{
		private int existingRecordId;

		private ITicketStatuRepository ticketStatuRepository;

		public AbstractApiTicketStatuRequestModelValidator(ITicketStatuRepository ticketStatuRepository)
		{
			this.ticketStatuRepository = ticketStatuRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTicketStatuRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 128);
		}
	}
}

/*<Codenesium>
    <Hash>230a281605f9d03bd91f79ca85f22b26</Hash>
</Codenesium>*/