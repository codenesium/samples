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
	public abstract class AbstractProductProductPhotoRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractProductProductPhotoRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			ProductProductPhotoModel model)
		{
			var record = new EFProductProductPhoto();

			this.mapper.ProductProductPhotoMapModelToEF(
				default (int),
				model,
				record);

			this.context.Set<EFProductProductPhoto>().Add(record);
			this.context.SaveChanges();
			return record.ProductID;
		}

		public virtual void Update(
			int productID,
			ProductProductPhotoModel model)
		{
			var record = this.SearchLinqEF(x => x.ProductID == productID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{productID}");
			}
			else
			{
				this.mapper.ProductProductPhotoMapModelToEF(
					productID,
					model,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int productID)
		{
			var record = this.SearchLinqEF(x => x.ProductID == productID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFProductProductPhoto>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int productID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.ProductID == productID, response);
			return response;
		}

		public virtual POCOProductProductPhoto GetByIdDirect(int productID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.ProductID == productID, response);
			return response.ProductProductPhotoes.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFProductProductPhoto, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
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

		public virtual List<POCOProductProductPhoto> GetWhereDirect(Expression<Func<EFProductProductPhoto, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.ProductProductPhotoes;
		}

		private void SearchLinqPOCO(Expression<Func<EFProductProductPhoto, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFProductProductPhoto> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.ProductProductPhotoMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFProductProductPhoto> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.ProductProductPhotoMapEFToPOCO(x, response));
		}

		protected virtual List<EFProductProductPhoto> SearchLinqEF(Expression<Func<EFProductProductPhoto, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFProductProductPhoto> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>22ecdcb38d295b1ee5983ad0e61477cf</Hash>
</Codenesium>*/