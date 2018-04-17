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
	public abstract class AbstractBOBusinessEntity
	{
		private IBusinessEntityRepository businessEntityRepository;
		private IBusinessEntityModelValidator businessEntityModelValidator;
		private ILogger logger;

		public AbstractBOBusinessEntity(
			ILogger logger,
			IBusinessEntityRepository businessEntityRepository,
			IBusinessEntityModelValidator businessEntityModelValidator)

		{
			this.businessEntityRepository = businessEntityRepository;
			this.businessEntityModelValidator = businessEntityModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			BusinessEntityModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.businessEntityModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.businessEntityRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			BusinessEntityModel model)
		{
			ActionResponse response = new ActionResponse(await this.businessEntityModelValidator.ValidateUpdateAsync(businessEntityID, model));

			if (response.Success)
			{
				this.businessEntityRepository.Update(businessEntityID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.businessEntityModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				this.businessEntityRepository.Delete(businessEntityID);
			}
			return response;
		}

		public virtual ApiResponse GetById(int businessEntityID)
		{
			return this.businessEntityRepository.GetById(businessEntityID);
		}

		public virtual POCOBusinessEntity GetByIdDirect(int businessEntityID)
		{
			return this.businessEntityRepository.GetByIdDirect(businessEntityID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFBusinessEntity, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.businessEntityRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.businessEntityRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOBusinessEntity> GetWhereDirect(Expression<Func<EFBusinessEntity, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.businessEntityRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>e3479402de3a183b142a8886baa4f3f0</Hash>
</Codenesium>*/