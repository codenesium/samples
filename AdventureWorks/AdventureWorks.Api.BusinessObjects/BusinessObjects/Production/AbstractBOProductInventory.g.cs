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
		private IProductInventoryModelValidator productInventoryModelValidator;
		private ILogger logger;

		public AbstractBOProductInventory(
			ILogger logger,
			IProductInventoryRepository productInventoryRepository,
			IProductInventoryModelValidator productInventoryModelValidator)

		{
			this.productInventoryRepository = productInventoryRepository;
			this.productInventoryModelValidator = productInventoryModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			ProductInventoryModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.productInventoryModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.productInventoryRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productID,
			ProductInventoryModel model)
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

		public virtual ApiResponse GetById(int productID)
		{
			return this.productInventoryRepository.GetById(productID);
		}

		public virtual POCOProductInventory GetByIdDirect(int productID)
		{
			return this.productInventoryRepository.GetByIdDirect(productID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFProductInventory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productInventoryRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productInventoryRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOProductInventory> GetWhereDirect(Expression<Func<EFProductInventory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productInventoryRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>89ec7b363ea097be304b61ad1a4d5fa3</Hash>
</Codenesium>*/