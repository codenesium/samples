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
	public abstract class AbstractBOProductPhoto: AbstractBOManager
	{
		private IProductPhotoRepository productPhotoRepository;
		private IApiProductPhotoModelValidator productPhotoModelValidator;
		private ILogger logger;

		public AbstractBOProductPhoto(
			ILogger logger,
			IProductPhotoRepository productPhotoRepository,
			IApiProductPhotoModelValidator productPhotoModelValidator)
			: base()

		{
			this.productPhotoRepository = productPhotoRepository;
			this.productPhotoModelValidator = productPhotoModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOProductPhoto>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productPhotoRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOProductPhoto> Get(int productPhotoID)
		{
			return this.productPhotoRepository.Get(productPhotoID);
		}

		public virtual async Task<CreateResponse<POCOProductPhoto>> Create(
			ApiProductPhotoModel model)
		{
			CreateResponse<POCOProductPhoto> response = new CreateResponse<POCOProductPhoto>(await this.productPhotoModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOProductPhoto record = await this.productPhotoRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productPhotoID,
			ApiProductPhotoModel model)
		{
			ActionResponse response = new ActionResponse(await this.productPhotoModelValidator.ValidateUpdateAsync(productPhotoID, model));

			if (response.Success)
			{
				await this.productPhotoRepository.Update(productPhotoID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int productPhotoID)
		{
			ActionResponse response = new ActionResponse(await this.productPhotoModelValidator.ValidateDeleteAsync(productPhotoID));

			if (response.Success)
			{
				await this.productPhotoRepository.Delete(productPhotoID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>468b4b32f928212225c2ff6a8ccedfce</Hash>
</Codenesium>*/