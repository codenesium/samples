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
	public abstract class AbstractBOScrapReason
	{
		private IScrapReasonRepository scrapReasonRepository;
		private IScrapReasonModelValidator scrapReasonModelValidator;
		private ILogger logger;

		public AbstractBOScrapReason(
			ILogger logger,
			IScrapReasonRepository scrapReasonRepository,
			IScrapReasonModelValidator scrapReasonModelValidator)

		{
			this.scrapReasonRepository = scrapReasonRepository;
			this.scrapReasonModelValidator = scrapReasonModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<short>> Create(
			ScrapReasonModel model)
		{
			CreateResponse<short> response = new CreateResponse<short>(await this.scrapReasonModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				short id = this.scrapReasonRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			short scrapReasonID,
			ScrapReasonModel model)
		{
			ActionResponse response = new ActionResponse(await this.scrapReasonModelValidator.ValidateUpdateAsync(scrapReasonID, model));

			if (response.Success)
			{
				this.scrapReasonRepository.Update(scrapReasonID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			short scrapReasonID)
		{
			ActionResponse response = new ActionResponse(await this.scrapReasonModelValidator.ValidateDeleteAsync(scrapReasonID));

			if (response.Success)
			{
				this.scrapReasonRepository.Delete(scrapReasonID);
			}
			return response;
		}

		public virtual ApiResponse GetById(short scrapReasonID)
		{
			return this.scrapReasonRepository.GetById(scrapReasonID);
		}

		public virtual POCOScrapReason GetByIdDirect(short scrapReasonID)
		{
			return this.scrapReasonRepository.GetByIdDirect(scrapReasonID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFScrapReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.scrapReasonRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.scrapReasonRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOScrapReason> GetWhereDirect(Expression<Func<EFScrapReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.scrapReasonRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>89b5c43e51a8d3e7f1464603c11f3d2d</Hash>
</Codenesium>*/