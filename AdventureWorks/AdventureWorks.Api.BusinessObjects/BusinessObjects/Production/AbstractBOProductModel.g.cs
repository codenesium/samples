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
	public abstract class AbstractBOProductModel
	{
		private IProductModelRepository productModelRepository;
		private IProductModelModelValidator productModelModelValidator;
		private ILogger logger;

		public AbstractBOProductModel(
			ILogger logger,
			IProductModelRepository productModelRepository,
			IProductModelModelValidator productModelModelValidator)

		{
			this.productModelRepository = productModelRepository;
			this.productModelModelValidator = productModelModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			ProductModelModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.productModelModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.productModelRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productModelID,
			ProductModelModel model)
		{
			ActionResponse response = new ActionResponse(await this.productModelModelValidator.ValidateUpdateAsync(productModelID, model));

			if (response.Success)
			{
				this.productModelRepository.Update(productModelID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int productModelID)
		{
			ActionResponse response = new ActionResponse(await this.productModelModelValidator.ValidateDeleteAsync(productModelID));

			if (response.Success)
			{
				this.productModelRepository.Delete(productModelID);
			}
			return response;
		}

		public virtual ApiResponse GetById(int productModelID)
		{
			return this.productModelRepository.GetById(productModelID);
		}

		public virtual POCOProductModel GetByIdDirect(int productModelID)
		{
			return this.productModelRepository.GetByIdDirect(productModelID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFProductModel, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productModelRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productModelRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOProductModel> GetWhereDirect(Expression<Func<EFProductModel, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productModelRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>bc59b6867b2f0d7a35c6ab38759ca3e7</Hash>
</Codenesium>*/