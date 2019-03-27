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
	public abstract class AbstractApiSaleServerRequestModelValidator : AbstractValidator<ApiSaleServerRequestModel>
	{
		private int existingRecordId;

		protected ISaleRepository SaleRepository { get; private set; }

		public AbstractApiSaleServerRequestModelValidator(ISaleRepository saleRepository)
		{
			this.SaleRepository = saleRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSaleServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
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
    <Hash>070a86d6760b311e3f116928e5ccee25</Hash>
</Codenesium>*/