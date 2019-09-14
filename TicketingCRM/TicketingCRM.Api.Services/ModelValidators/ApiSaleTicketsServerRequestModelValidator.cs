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
	public class ApiSaleTicketsServerRequestModelValidator : AbstractValidator<ApiSaleTicketsServerRequestModel>, IApiSaleTicketsServerRequestModelValidator
	{
		private int existingRecordId;

		protected ISaleTicketsRepository SaleTicketsRepository { get; private set; }

		public ApiSaleTicketsServerRequestModelValidator(ISaleTicketsRepository saleTicketsRepository)
		{
			this.SaleTicketsRepository = saleTicketsRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSaleTicketsServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiSaleTicketsServerRequestModel model)
		{
			this.SaleIdRules();
			this.TicketIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSaleTicketsServerRequestModel model)
		{
			this.SaleIdRules();
			this.TicketIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
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
    <Hash>051abc401ce2ae2b62eac2ccfff73d58</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/