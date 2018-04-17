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
	public abstract class AbstractBOSalesReason
	{
		private ISalesReasonRepository salesReasonRepository;
		private ISalesReasonModelValidator salesReasonModelValidator;
		private ILogger logger;

		public AbstractBOSalesReason(
			ILogger logger,
			ISalesReasonRepository salesReasonRepository,
			ISalesReasonModelValidator salesReasonModelValidator)

		{
			this.salesReasonRepository = salesReasonRepository;
			this.salesReasonModelValidator = salesReasonModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			SalesReasonModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.salesReasonModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.salesReasonRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int salesReasonID,
			SalesReasonModel model)
		{
			ActionResponse response = new ActionResponse(await this.salesReasonModelValidator.ValidateUpdateAsync(salesReasonID, model));

			if (response.Success)
			{
				this.salesReasonRepository.Update(salesReasonID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int salesReasonID)
		{
			ActionResponse response = new ActionResponse(await this.salesReasonModelValidator.ValidateDeleteAsync(salesReasonID));

			if (response.Success)
			{
				this.salesReasonRepository.Delete(salesReasonID);
			}
			return response;
		}

		public virtual ApiResponse GetById(int salesReasonID)
		{
			return this.salesReasonRepository.GetById(salesReasonID);
		}

		public virtual POCOSalesReason GetByIdDirect(int salesReasonID)
		{
			return this.salesReasonRepository.GetByIdDirect(salesReasonID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFSalesReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.salesReasonRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.salesReasonRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOSalesReason> GetWhereDirect(Expression<Func<EFSalesReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.salesReasonRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>0e313cff69c664fea98c9c939f390caa</Hash>
</Codenesium>*/