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

		public virtual ApiResponse GetById(int productPhotoID)
		{
			return this.productPhotoRepository.GetById(productPhotoID);
		}

		public virtual POCOProductPhoto GetByIdDirect(int productPhotoID)
		{
			return this.productPhotoRepository.GetByIdDirect(productPhotoID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFProductPhoto, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productPhotoRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productPhotoRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOProductPhoto> GetWhereDirect(Expression<Func<EFProductPhoto, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.productPhotoRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>6a67b6bd761e0daf13428db6dc952f2a</Hash>
</Codenesium>*/