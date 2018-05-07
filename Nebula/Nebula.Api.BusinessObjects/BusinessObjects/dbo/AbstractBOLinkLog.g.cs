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
	public abstract class AbstractBOLinkLog
	{
		private ILinkLogRepository linkLogRepository;
		private ILinkLogModelValidator linkLogModelValidator;
		private ILogger logger;

		public AbstractBOLinkLog(
			ILogger logger,
			ILinkLogRepository linkLogRepository,
			ILinkLogModelValidator linkLogModelValidator)

		{
			this.linkLogRepository = linkLogRepository;
			this.linkLogModelValidator = linkLogModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			LinkLogModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.linkLogModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.linkLogRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			LinkLogModel model)
		{
			ActionResponse response = new ActionResponse(await this.linkLogModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.linkLogRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.linkLogModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.linkLogRepository.Delete(id);
			}
			return response;
		}

		public virtual POCOLinkLog Get(int id)
		{
			return this.linkLogRepository.Get(id);
		}

		public virtual List<POCOLinkLog> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.linkLogRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>fceebbe4515789fc863c9535ffecdf5b</Hash>
</Codenesium>*/