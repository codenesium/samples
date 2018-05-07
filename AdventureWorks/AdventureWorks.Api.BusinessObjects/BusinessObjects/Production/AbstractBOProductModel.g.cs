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

		public virtual POCOProductModel Get(int productModelID)
		{
			return this.productModelRepository.Get(productModelID);
		}

		public virtual List<POCOProductModel> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productModelRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>cfbf4b611d3e64749159def7e14d8bc7</Hash>
</Codenesium>*/