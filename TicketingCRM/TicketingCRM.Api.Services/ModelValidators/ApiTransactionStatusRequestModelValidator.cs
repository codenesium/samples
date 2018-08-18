using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public class ApiTransactionStatusRequestModelValidator : AbstractApiTransactionStatusRequestModelValidator, IApiTransactionStatusRequestModelValidator
	{
		public ApiTransactionStatusRequestModelValidator(ITransactionStatusRepository transactionStatusRepository)
			: base(transactionStatusRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiTransactionStatusRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTransactionStatusRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>2679c1433f1fdc6a7c77c7649bd0fe3c</Hash>
</Codenesium>*/