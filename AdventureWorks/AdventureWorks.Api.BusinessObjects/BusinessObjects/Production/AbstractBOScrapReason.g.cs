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

		public virtual POCOScrapReason Get(short scrapReasonID)
		{
			return this.scrapReasonRepository.Get(scrapReasonID);
		}

		public virtual List<POCOScrapReason> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.scrapReasonRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>423722a2dbf260a8547d06e2e3c1157a</Hash>
</Codenesium>*/