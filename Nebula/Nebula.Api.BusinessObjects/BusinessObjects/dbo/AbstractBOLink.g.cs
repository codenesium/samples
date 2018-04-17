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

		public virtual async Task<CreateResponse<int>> Create(
			LinkModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.linkModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.linkRepository.Create(model);
				response.SetId(id);
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

		public virtual ApiResponse GetById(int id)
		{
			return this.linkRepository.GetById(id);
		}

		public virtual POCOLink GetByIdDirect(int id)
		{
			return this.linkRepository.GetByIdDirect(id);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFLink, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.linkRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.linkRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOLink> GetWhereDirect(Expression<Func<EFLink, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.linkRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>5b169cf031f5c76a19768cc4db454795</Hash>
</Codenesium>*/