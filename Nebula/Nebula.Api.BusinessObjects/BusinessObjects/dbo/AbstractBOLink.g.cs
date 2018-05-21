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
	public abstract class AbstractBOLink: AbstractBOManager
	{
		private ILinkRepository linkRepository;
		private IApiLinkModelValidator linkModelValidator;
		private ILogger logger;

		public AbstractBOLink(
			ILogger logger,
			ILinkRepository linkRepository,
			IApiLinkModelValidator linkModelValidator)
			: base()

		{
			this.linkRepository = linkRepository;
			this.linkModelValidator = linkModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOLink>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.linkRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOLink> Get(int id)
		{
			return this.linkRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOLink>> Create(
			ApiLinkModel model)
		{
			CreateResponse<POCOLink> response = new CreateResponse<POCOLink>(await this.linkModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOLink record = await this.linkRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiLinkModel model)
		{
			ActionResponse response = new ActionResponse(await this.linkModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				await this.linkRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.linkModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.linkRepository.Delete(id);
			}
			return response;
		}

		public async Task<POCOLink> GetExternalId(Guid externalId)
		{
			return await this.linkRepository.GetExternalId(externalId);
		}
		public async Task<List<POCOLink>> GetChainId(int chainId)
		{
			return await this.linkRepository.GetChainId(chainId);
		}
	}
}

/*<Codenesium>
    <Hash>f52d5efae89fbe7872dddcece692d2ed</Hash>
</Codenesium>*/