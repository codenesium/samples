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
	public abstract class AbstractBOScrapReason: AbstractBOManager
	{
		private IScrapReasonRepository scrapReasonRepository;
		private IApiScrapReasonModelValidator scrapReasonModelValidator;
		private ILogger logger;

		public AbstractBOScrapReason(
			ILogger logger,
			IScrapReasonRepository scrapReasonRepository,
			IApiScrapReasonModelValidator scrapReasonModelValidator)
			: base()

		{
			this.scrapReasonRepository = scrapReasonRepository;
			this.scrapReasonModelValidator = scrapReasonModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOScrapReason>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.scrapReasonRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOScrapReason> Get(short scrapReasonID)
		{
			return this.scrapReasonRepository.Get(scrapReasonID);
		}

		public virtual async Task<CreateResponse<POCOScrapReason>> Create(
			ApiScrapReasonModel model)
		{
			CreateResponse<POCOScrapReason> response = new CreateResponse<POCOScrapReason>(await this.scrapReasonModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOScrapReason record = await this.scrapReasonRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			short scrapReasonID,
			ApiScrapReasonModel model)
		{
			ActionResponse response = new ActionResponse(await this.scrapReasonModelValidator.ValidateUpdateAsync(scrapReasonID, model));

			if (response.Success)
			{
				await this.scrapReasonRepository.Update(scrapReasonID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			short scrapReasonID)
		{
			ActionResponse response = new ActionResponse(await this.scrapReasonModelValidator.ValidateDeleteAsync(scrapReasonID));

			if (response.Success)
			{
				await this.scrapReasonRepository.Delete(scrapReasonID);
			}
			return response;
		}

		public async Task<POCOScrapReason> GetName(string name)
		{
			return await this.scrapReasonRepository.GetName(name);
		}
	}
}

/*<Codenesium>
    <Hash>23fc38099de95edb82e96b6cf7f0c4bc</Hash>
</Codenesium>*/