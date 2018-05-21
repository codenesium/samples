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
	public abstract class AbstractBOLinkStatus: AbstractBOManager
	{
		private ILinkStatusRepository linkStatusRepository;
		private IApiLinkStatusModelValidator linkStatusModelValidator;
		private ILogger logger;

		public AbstractBOLinkStatus(
			ILogger logger,
			ILinkStatusRepository linkStatusRepository,
			IApiLinkStatusModelValidator linkStatusModelValidator)
			: base()

		{
			this.linkStatusRepository = linkStatusRepository;
			this.linkStatusModelValidator = linkStatusModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOLinkStatus>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.linkStatusRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOLinkStatus> Get(int id)
		{
			return this.linkStatusRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOLinkStatus>> Create(
			ApiLinkStatusModel model)
		{
			CreateResponse<POCOLinkStatus> response = new CreateResponse<POCOLinkStatus>(await this.linkStatusModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOLinkStatus record = await this.linkStatusRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiLinkStatusModel model)
		{
			ActionResponse response = new ActionResponse(await this.linkStatusModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				await this.linkStatusRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.linkStatusModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.linkStatusRepository.Delete(id);
			}
			return response;
		}

		public async Task<POCOLinkStatus> Name(string name)
		{
			return await this.linkStatusRepository.Name(name);
		}
	}
}

/*<Codenesium>
    <Hash>996a7ef5294bbd2a3c3db7b5a083f0c9</Hash>
</Codenesium>*/