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
	public abstract class AbstractBOClasp
	{
		private IClaspRepository claspRepository;
		private IClaspModelValidator claspModelValidator;
		private ILogger logger;

		public AbstractBOClasp(
			ILogger logger,
			IClaspRepository claspRepository,
			IClaspModelValidator claspModelValidator)

		{
			this.claspRepository = claspRepository;
			this.claspModelValidator = claspModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			ClaspModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.claspModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.claspRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ClaspModel model)
		{
			ActionResponse response = new ActionResponse(await this.claspModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.claspRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.claspModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.claspRepository.Delete(id);
			}
			return response;
		}

		public virtual ApiResponse GetById(int id)
		{
			return this.claspRepository.GetById(id);
		}

		public virtual POCOClasp GetByIdDirect(int id)
		{
			return this.claspRepository.GetByIdDirect(id);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFClasp, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.claspRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.claspRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOClasp> GetWhereDirect(Expression<Func<EFClasp, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.claspRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>049bb14805854444fb27044f01348081</Hash>
</Codenesium>*/