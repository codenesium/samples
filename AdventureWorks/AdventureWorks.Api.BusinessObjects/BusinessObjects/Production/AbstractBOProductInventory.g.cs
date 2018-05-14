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
	public abstract class AbstractBOProductInventory
	{
		private IProductInventoryRepository productInventoryRepository;
		private IApiProductInventoryModelValidator productInventoryModelValidator;
		private ILogger logger;

		public AbstractBOProductInventory(
			ILogger logger,
			IProductInventoryRepository productInventoryRepository,
			IApiProductInventoryModelValidator productInventoryModelValidator)

		{
			this.productInventoryRepository = productInventoryRepository;
			this.productInventoryModelValidator = productInventoryModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOProductInventory> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productInventoryRepository.All(skip, take, orderClause);
		}

		public virtual POCOProductInventory Get(int productID)
		{
			return this.productInventoryRepository.Get(productID);
		}

		public virtual async Task<CreateResponse<POCOProductInventory>> Create(
			ApiProductInventoryModel model)
		{
			CreateResponse<POCOProductInventory> response = new CreateResponse<POCOProductInventory>(await this.productInventoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOProductInventory record = this.productInventoryRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productID,
			ApiProductInventoryModel model)
		{
			ActionResponse response = new ActionResponse(await this.productInventoryModelValidator.ValidateUpdateAsync(productID, model));

			if (response.Success)
			{
				this.productInventoryRepository.Update(productID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int productID)
		{
			ActionResponse response = new ActionResponse(await this.productInventoryModelValidator.ValidateDeleteAsync(productID));

			if (response.Success)
			{
				this.productInventoryRepository.Delete(productID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>920f9edc4765681593d487d7fce02bee</Hash>
</Codenesium>*/