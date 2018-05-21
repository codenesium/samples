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
	public abstract class AbstractBOProductProductPhoto: AbstractBOManager
	{
		private IProductProductPhotoRepository productProductPhotoRepository;
		private IApiProductProductPhotoModelValidator productProductPhotoModelValidator;
		private ILogger logger;

		public AbstractBOProductProductPhoto(
			ILogger logger,
			IProductProductPhotoRepository productProductPhotoRepository,
			IApiProductProductPhotoModelValidator productProductPhotoModelValidator)
			: base()

		{
			this.productProductPhotoRepository = productProductPhotoRepository;
			this.productProductPhotoModelValidator = productProductPhotoModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOProductProductPhoto>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productProductPhotoRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOProductProductPhoto> Get(int productID)
		{
			return this.productProductPhotoRepository.Get(productID);
		}

		public virtual async Task<CreateResponse<POCOProductProductPhoto>> Create(
			ApiProductProductPhotoModel model)
		{
			CreateResponse<POCOProductProductPhoto> response = new CreateResponse<POCOProductProductPhoto>(await this.productProductPhotoModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOProductProductPhoto record = await this.productProductPhotoRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int productID,
			ApiProductProductPhotoModel model)
		{
			ActionResponse response = new ActionResponse(await this.productProductPhotoModelValidator.ValidateUpdateAsync(productID, model));

			if (response.Success)
			{
				await this.productProductPhotoRepository.Update(productID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int productID)
		{
			ActionResponse response = new ActionResponse(await this.productProductPhotoModelValidator.ValidateDeleteAsync(productID));

			if (response.Success)
			{
				await this.productProductPhotoRepository.Delete(productID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>624634d354274f409c8ab1ac265dafe3</Hash>
</Codenesium>*/