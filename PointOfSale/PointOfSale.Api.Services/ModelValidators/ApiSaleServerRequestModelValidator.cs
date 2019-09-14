using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using PointOfSaleNS.Api.Contracts;
using PointOfSaleNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PointOfSaleNS.Api.Services
{
	public class ApiSaleServerRequestModelValidator : AbstractValidator<ApiSaleServerRequestModel>, IApiSaleServerRequestModelValidator
	{
		private int existingRecordId;

		protected ISaleRepository SaleRepository { get; private set; }

		public ApiSaleServerRequestModelValidator(ISaleRepository saleRepository)
		{
			this.SaleRepository = saleRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSaleServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiSaleServerRequestModel model)
		{
			this.CustomerIdRules();
			this.DateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSaleServerRequestModel model)
		{
			this.CustomerIdRules();
			this.DateRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}

		public virtual void CustomerIdRules()
		{
		}

		public virtual void DateRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>cddbf9b834d98f19c9803e6168f062f6</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/