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
	public abstract class AbstractApiSaleTicketsServerRequestModelValidator : AbstractValidator<ApiSaleTicketsServerRequestModel>
	{
		private int existingRecordId;

		protected ISaleTicketsRepository SaleTicketsRepository { get; private set; }

		public AbstractApiSaleTicketsServerRequestModelValidator(ISaleTicketsRepository saleTicketsRepository)
		{
			this.SaleTicketsRepository = saleTicketsRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSaleTicketsServerRequestModel model, int id)
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
			var record = await this.SaleTicketsRepository.SaleBySaleId(id);

			return record != null;
		}

		protected async Task<bool> BeValidTicketByTicketId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.SaleTicketsRepository.TicketByTicketId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>b210aafe53bd952f83abcaa9bf957c82</Hash>
</Codenesium>*/