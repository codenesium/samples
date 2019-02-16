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
	public abstract class AbstractApiSaleTicketServerRequestModelValidator : AbstractValidator<ApiSaleTicketServerRequestModel>
	{
		private int existingRecordId;

		protected ISaleTicketRepository SaleTicketRepository { get; private set; }

		public AbstractApiSaleTicketServerRequestModelValidator(ISaleTicketRepository saleTicketRepository)
		{
			this.SaleTicketRepository = saleTicketRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSaleTicketServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void SaleIdRules()
		{
			this.RuleFor(x => x.SaleId).MustAsync(this.BeValidSaleBySaleId).When(x => !x?.SaleId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void TicketIdRules()
		{
			this.RuleFor(x => x.TicketId).MustAsync(this.BeValidTicketByTicketId).When(x => !x?.TicketId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidSaleBySaleId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.SaleTicketRepository.SaleBySaleId(id);

			return record != null;
		}

		protected async Task<bool> BeValidTicketByTicketId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.SaleTicketRepository.TicketByTicketId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>7d80caaefe9188d2410dadb6ccb79670</Hash>
</Codenesium>*/