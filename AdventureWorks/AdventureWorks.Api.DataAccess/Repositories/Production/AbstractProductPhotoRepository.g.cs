using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractProductPhotoRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractProductPhotoRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			ProductPhotoModel model)
		{
			var record = new EFProductPhoto();

			this.mapper.ProductPhotoMapModelToEF(
				default (int),
				model,
				record);

			this.context.Set<EFProductPhoto>().Add(record);
			this.context.SaveChanges();
			return record.ProductPhotoID;
		}

		public virtual void Update(
			int productPhotoID,
			ProductPhotoModel model)
		{
			var record = this.SearchLinqEF(x => x.ProductPhotoID == productPhotoID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{productPhotoID}");
			}
			else
			{
				this.mapper.ProductPhotoMapModelToEF(
					productPhotoID,
					model,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int productPhotoID)
		{
			var record = this.SearchLinqEF(x => x.ProductPhotoID == productPhotoID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFProductPhoto>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int productPhotoID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.ProductPhotoID == productPhotoID, response);
			return response;
		}

		public virtual POCOProductPhoto GetByIdDirect(int productPhotoID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.ProductPhotoID == productPhotoID, response);
			return response.ProductPhotoes.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFProductPhoto, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOProductPhoto> GetWhereDirect(Expression<Func<EFProductPhoto, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.ProductPhotoes;
		}

		private void SearchLinqPOCO(Expression<Func<EFProductPhoto, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFProductPhoto> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.ProductPhotoMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFProductPhoto> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.ProductPhotoMapEFToPOCO(x, response));
		}

		protected virtual List<EFProductPhoto> SearchLinqEF(Expression<Func<EFProductPhoto, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFProductPhoto> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>e2495699e5ce741a51d14a500c60c530</Hash>
</Codenesium>*/