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
	public abstract class AbstractBOProductModelProductDescriptionCulture
	{
		private IProductModelProductDescriptionCultureRepository productModelProductDescriptionCultureRepository;
		private IProductModelProductDescriptionCultureModelValidator productModelProductDescriptionCultureModelValidator;
		private ILogger logger;

		public AbstractBOProductModelProductDescriptionCulture(
			ILogger logger,
			IProductModelProductDescriptionCultureRepository productModelProductDescriptionCultureRepository,
			IProductModelProductDescriptionCultureModelValidator productModelProductDescriptionCultureModelValidator)

		{
			this.productModelProductDescriptionCultureRepository = productModelProductDescriptionCultureRepository;
			this.productModelProductDescriptionCultureModelValidator = productModelProductDescriptionCultureModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			ProductModelProductDescriptionCultureModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.productModelProductDescriptionCultureModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.productModelProductDescriptionCultureRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productModelID,
			ProductModelProductDescriptionCultureModel model)
		{
			ActionResponse response = new ActionResponse(await this.productModelProductDescriptionCultureModelValidator.ValidateUpdateAsync(productModelID, model));

			if (response.Success)
			{
				this.productModelProductDescriptionCultureRepository.Update(productModelID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int productModelID)
		{
			ActionResponse response = new ActionResponse(await this.productModelProductDescriptionCultureModelValidator.ValidateDeleteAsync(productModelID));

			if (response.Success)
			{
				this.productModelProductDescriptionCultureRepository.Delete(productModelID);
			}
			return response;
		}

		public virtual POCOProductModelProductDescriptionCulture Get(int productModelID)
		{
			return this.productModelProductDescriptionCultureRepository.Get(productModelID);
		}

		public virtual List<POCOProductModelProductDescriptionCulture> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productModelProductDescriptionCultureRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>8a25399e95f8e5db1e4e080edc86d275</Hash>
</Codenesium>*/