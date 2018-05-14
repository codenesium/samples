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
		private IApiProductModelProductDescriptionCultureModelValidator productModelProductDescriptionCultureModelValidator;
		private ILogger logger;

		public AbstractBOProductModelProductDescriptionCulture(
			ILogger logger,
			IProductModelProductDescriptionCultureRepository productModelProductDescriptionCultureRepository,
			IApiProductModelProductDescriptionCultureModelValidator productModelProductDescriptionCultureModelValidator)

		{
			this.productModelProductDescriptionCultureRepository = productModelProductDescriptionCultureRepository;
			this.productModelProductDescriptionCultureModelValidator = productModelProductDescriptionCultureModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOProductModelProductDescriptionCulture> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productModelProductDescriptionCultureRepository.All(skip, take, orderClause);
		}

		public virtual POCOProductModelProductDescriptionCulture Get(int productModelID)
		{
			return this.productModelProductDescriptionCultureRepository.Get(productModelID);
		}

		public virtual async Task<CreateResponse<POCOProductModelProductDescriptionCulture>> Create(
			ApiProductModelProductDescriptionCultureModel model)
		{
			CreateResponse<POCOProductModelProductDescriptionCulture> response = new CreateResponse<POCOProductModelProductDescriptionCulture>(await this.productModelProductDescriptionCultureModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOProductModelProductDescriptionCulture record = this.productModelProductDescriptionCultureRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productModelID,
			ApiProductModelProductDescriptionCultureModel model)
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
	}
}

/*<Codenesium>
    <Hash>e21620e549a7df80bebcb78162d34a51</Hash>
</Codenesium>*/