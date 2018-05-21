using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOSalesReason: AbstractBOManager
	{
		private ISalesReasonRepository salesReasonRepository;
		private IApiSalesReasonModelValidator salesReasonModelValidator;
		private ILogger logger;

		public AbstractBOSalesReason(
			ILogger logger,
			ISalesReasonRepository salesReasonRepository,
			IApiSalesReasonModelValidator salesReasonModelValidator)
			: base()

		{
			this.salesReasonRepository = salesReasonRepository;
			this.salesReasonModelValidator = salesReasonModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOSalesReason>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.salesReasonRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOSalesReason> Get(int salesReasonID)
		{
			return this.salesReasonRepository.Get(salesReasonID);
		}

		public virtual async Task<CreateResponse<POCOSalesReason>> Create(
			ApiSalesReasonModel model)
		{
			CreateResponse<POCOSalesReason> response = new CreateResponse<POCOSalesReason>(await this.salesReasonModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOSalesReason record = await this.salesReasonRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int salesReasonID,
			ApiSalesReasonModel model)
		{
			ActionResponse response = new ActionResponse(await this.salesReasonModelValidator.ValidateUpdateAsync(salesReasonID, model));

			if (response.Success)
			{
				await this.salesReasonRepository.Update(salesReasonID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int salesReasonID)
		{
			ActionResponse response = new ActionResponse(await this.salesReasonModelValidator.ValidateDeleteAsync(salesReasonID));

			if (response.Success)
			{
				await this.salesReasonRepository.Delete(salesReasonID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ae4d158b13a9d12516668ea3ee2a0d59</Hash>
</Codenesium>*/