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
	public abstract class AbstractBOProductProductPhoto
	{
		private IProductProductPhotoRepository productProductPhotoRepository;
		private IProductProductPhotoModelValidator productProductPhotoModelValidator;
		private ILogger logger;

		public AbstractBOProductProductPhoto(
			ILogger logger,
			IProductProductPhotoRepository productProductPhotoRepository,
			IProductProductPhotoModelValidator productProductPhotoModelValidator)

		{
			this.productProductPhotoRepository = productProductPhotoRepository;
			this.productProductPhotoModelValidator = productProductPhotoModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			ProductProductPhotoModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.productProductPhotoModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.productProductPhotoRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productID,
			ProductProductPhotoModel model)
		{
			ActionResponse response = new ActionResponse(await this.productProductPhotoModelValidator.ValidateUpdateAsync(productID, model));

			if (response.Success)
			{
				this.productProductPhotoRepository.Update(productID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int productID)
		{
			ActionResponse response = new ActionResponse(await this.productProductPhotoModelValidator.ValidateDeleteAsync(productID));

			if (response.Success)
			{
				this.productProductPhotoRepository.Delete(productID);
			}
			return response;
		}

		public virtual POCOProductProductPhoto Get(int productID)
		{
			return this.productProductPhotoRepository.Get(productID);
		}

		public virtual List<POCOProductProductPhoto> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productProductPhotoRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>79440d023a47f85cfc2ba789837c1a6e</Hash>
</Codenesium>*/