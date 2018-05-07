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

		public virtual POCOBusinessEntity Get(int businessEntityID)
		{
			return this.businessEntityRepository.Get(businessEntityID);
		}

		public virtual List<POCOBusinessEntity> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.businessEntityRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>2a60016c9981383977603459b4fea049</Hash>
</Codenesium>*/