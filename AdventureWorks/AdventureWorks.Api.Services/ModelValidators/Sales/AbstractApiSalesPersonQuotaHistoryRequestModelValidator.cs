using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiSalesPersonQuotaHistoryRequestModelValidator : AbstractValidator<ApiSalesPersonQuotaHistoryRequestModel>
	{
		private int existingRecordId;

		private ISalesPersonQuotaHistoryRepository salesPersonQuotaHistoryRepository;

		public AbstractApiSalesPersonQuotaHistoryRequestModelValidator(ISalesPersonQuotaHistoryRepository salesPersonQuotaHistoryRepository)
		{
			this.salesPersonQuotaHistoryRepository = salesPersonQuotaHistoryRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSalesPersonQuotaHistoryRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void QuotaDateRules()
		{
		}

		public virtual void RowguidRules()
		{
		}

		public virtual void SalesQuotaRules()
		{
		}

		private async Task<bool> BeValidSalesPersonByBusinessEntityID(int id,  CancellationToken cancellationToken)
		{
			var record = await this.salesPersonQuotaHistoryRepository.SalesPersonByBusinessEntityID(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>faed6c5dadf15273a1b731a94df512cd</Hash>
</Codenesium>*/