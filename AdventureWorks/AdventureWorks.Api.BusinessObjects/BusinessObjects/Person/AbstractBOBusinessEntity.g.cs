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
		private IApiBusinessEntityModelValidator businessEntityModelValidator;
		private ILogger logger;

		public AbstractBOBusinessEntity(
			ILogger logger,
			IBusinessEntityRepository businessEntityRepository,
			IApiBusinessEntityModelValidator businessEntityModelValidator)

		{
			this.businessEntityRepository = businessEntityRepository;
			this.businessEntityModelValidator = businessEntityModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOBusinessEntity> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.businessEntityRepository.All(skip, take, orderClause);
		}

		public virtual POCOBusinessEntity Get(int businessEntityID)
		{
			return this.businessEntityRepository.Get(businessEntityID);
		}

		public virtual async Task<CreateResponse<POCOBusinessEntity>> Create(
			ApiBusinessEntityModel model)
		{
			CreateResponse<POCOBusinessEntity> response = new CreateResponse<POCOBusinessEntity>(await this.businessEntityModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOBusinessEntity record = this.businessEntityRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			ApiBusinessEntityModel model)
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
	}
}

/*<Codenesium>
    <Hash>8e9c200ae77eb5b3c3e94184b2f57bdd</Hash>
</Codenesium>*/