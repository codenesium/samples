using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public abstract class AbstractBOLink
	{
		private ILinkRepository linkRepository;
		private ILinkModelValidator linkModelValidator;
		private ILogger logger;

		public AbstractBOLink(
			ILogger logger,
			ILinkRepository linkRepository,
			ILinkModelValidator linkModelValidator)

		{
			this.linkRepository = linkRepository;
			this.linkModelValidator = linkModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOLink> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.linkRepository.All(skip, take, orderClause);
		}

		public virtual POCOLink Get(int id)
		{
			return this.linkRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOLink>> Create(
			LinkModel model)
		{
			CreateResponse<POCOLink> response = new CreateResponse<POCOLink>(await this.linkModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOLink record = this.linkRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			LinkModel model)
		{
			ActionResponse response = new ActionResponse(await this.linkModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.linkRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.linkModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.linkRepository.Delete(id);
			}
			return response;
		}

		public List<POCOLink> ChainId(int chainId)
		{
			return this.linkRepository.ChainId(chainId);
		}
		public POCOLink ExternalId(Guid externalId)
		{
			return this.linkRepository.ExternalId(externalId);
		}
	}
}

/*<Codenesium>
    <Hash>d8cb81baf752a510e900ed142db760e3</Hash>
</Codenesium>*/