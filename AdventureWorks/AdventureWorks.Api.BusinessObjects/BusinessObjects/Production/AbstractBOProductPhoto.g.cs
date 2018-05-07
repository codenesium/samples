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
	public abstract class AbstractBOProductPhoto
	{
		private IProductPhotoRepository productPhotoRepository;
		private IProductPhotoModelValidator productPhotoModelValidator;
		private ILogger logger;

		public AbstractBOProductPhoto(
			ILogger logger,
			IProductPhotoRepository productPhotoRepository,
			IProductPhotoModelValidator productPhotoModelValidator)

		{
			this.productPhotoRepository = productPhotoRepository;
			this.productPhotoModelValidator = productPhotoModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			ProductPhotoModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.productPhotoModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.productPhotoRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productPhotoID,
			ProductPhotoModel model)
		{
			ActionResponse response = new ActionResponse(await this.productPhotoModelValidator.ValidateUpdateAsync(productPhotoID, model));

			if (response.Success)
			{
				this.productPhotoRepository.Update(productPhotoID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int productPhotoID)
		{
			ActionResponse response = new ActionResponse(await this.productPhotoModelValidator.ValidateDeleteAsync(productPhotoID));

			if (response.Success)
			{
				this.productPhotoRepository.Delete(productPhotoID);
			}
			return response;
		}

		public virtual POCOProductPhoto Get(int productPhotoID)
		{
			return this.productPhotoRepository.Get(productPhotoID);
		}

		public virtual List<POCOProductPhoto> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productPhotoRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>12782fd324ede3e4bd50ca643bcf63fa</Hash>
</Codenesium>*/