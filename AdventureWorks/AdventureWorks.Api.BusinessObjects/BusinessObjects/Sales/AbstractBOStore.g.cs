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
		private IStoreModelValidator storeModelValidator;
		private ILogger logger;

		public AbstractBOStore(
			ILogger logger,
			IStoreRepository storeRepository,
			IStoreModelValidator storeModelValidator)

		{
			this.storeRepository = storeRepository;
			this.storeModelValidator = storeModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			StoreModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.storeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.storeRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			StoreModel model)
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

		public virtual POCOStore Get(int businessEntityID)
		{
			return this.storeRepository.Get(businessEntityID);
		}

		public virtual List<POCOStore> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.storeRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>1292acd4a4fb2790a59764f435222174</Hash>
</Codenesium>*/