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
	public abstract class AbstractBOStore
	{
		private IStoreRepository storeRepository;
		private IApiStoreModelValidator storeModelValidator;
		private ILogger logger;

		public AbstractBOStore(
			ILogger logger,
			IStoreRepository storeRepository,
			IApiStoreModelValidator storeModelValidator)

		{
			this.storeRepository = storeRepository;
			this.storeModelValidator = storeModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOStore> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.storeRepository.All(skip, take, orderClause);
		}

		public virtual POCOStore Get(int businessEntityID)
		{
			return this.storeRepository.Get(businessEntityID);
		}

		public virtual async Task<CreateResponse<POCOStore>> Create(
			ApiStoreModel model)
		{
			CreateResponse<POCOStore> response = new CreateResponse<POCOStore>(await this.storeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOStore record = this.storeRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			ApiStoreModel model)
		{
			ActionResponse response = new ActionResponse(await this.storeModelValidator.ValidateUpdateAsync(businessEntityID, model));

			if (response.Success)
			{
				this.storeRepository.Update(businessEntityID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.storeModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				this.storeRepository.Delete(businessEntityID);
			}
			return response;
		}

		public List<POCOStore> GetSalesPersonID(Nullable<int> salesPersonID)
		{
			return this.storeRepository.GetSalesPersonID(salesPersonID);
		}
		public List<POCOStore> GetDemographics(string demographics)
		{
			return this.storeRepository.GetDemographics(demographics);
		}
	}
}

/*<Codenesium>
    <Hash>e9382575365c8b24e2a3385273886448</Hash>
</Codenesium>*/