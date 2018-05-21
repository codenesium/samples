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
	public abstract class AbstractBOBusinessEntity: AbstractBOManager
	{
		private IBusinessEntityRepository businessEntityRepository;
		private IApiBusinessEntityModelValidator businessEntityModelValidator;
		private ILogger logger;

		public AbstractBOBusinessEntity(
			ILogger logger,
			IBusinessEntityRepository businessEntityRepository,
			IApiBusinessEntityModelValidator businessEntityModelValidator)
			: base()

		{
			this.businessEntityRepository = businessEntityRepository;
			this.businessEntityModelValidator = businessEntityModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOBusinessEntity>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.businessEntityRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOBusinessEntity> Get(int businessEntityID)
		{
			return this.businessEntityRepository.Get(businessEntityID);
		}

		public virtual async Task<CreateResponse<POCOBusinessEntity>> Create(
			ApiBusinessEntityModel model)
		{
			CreateResponse<POCOBusinessEntity> response = new CreateResponse<POCOBusinessEntity>(await this.businessEntityModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOBusinessEntity record = await this.businessEntityRepository.Create(model);

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
				await this.businessEntityRepository.Update(businessEntityID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.businessEntityModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				await this.businessEntityRepository.Delete(businessEntityID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>4ddf454d213ec267d990ecc02cbeab5d</Hash>
</Codenesium>*/