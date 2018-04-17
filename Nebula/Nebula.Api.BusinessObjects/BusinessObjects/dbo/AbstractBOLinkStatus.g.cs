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
	public abstract class AbstractBOLinkStatus
	{
		private ILinkStatusRepository linkStatusRepository;
		private ILinkStatusModelValidator linkStatusModelValidator;
		private ILogger logger;

		public AbstractBOLinkStatus(
			ILogger logger,
			ILinkStatusRepository linkStatusRepository,
			ILinkStatusModelValidator linkStatusModelValidator)

		{
			this.linkStatusRepository = linkStatusRepository;
			this.linkStatusModelValidator = linkStatusModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			LinkStatusModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.linkStatusModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.linkStatusRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			LinkStatusModel model)
		{
			ActionResponse response = new ActionResponse(await this.linkStatusModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.linkStatusRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.linkStatusModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.linkStatusRepository.Delete(id);
			}
			return response;
		}

		public virtual ApiResponse GetById(int id)
		{
			return this.linkStatusRepository.GetById(id);
		}

		public virtual POCOLinkStatus GetByIdDirect(int id)
		{
			return this.linkStatusRepository.GetByIdDirect(id);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFLinkStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.linkStatusRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.linkStatusRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOLinkStatus> GetWhereDirect(Expression<Func<EFLinkStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.linkStatusRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>7b63a585a0ac237908d8793a972e732c</Hash>
</Codenesium>*/