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
	public abstract class AbstractProductModelProductDescriptionCultureRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractProductModelProductDescriptionCultureRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			ProductModelProductDescriptionCultureModel model)
		{
			var record = new EFProductModelProductDescriptionCulture();

			this.mapper.ProductModelProductDescriptionCultureMapModelToEF(
				default (int),
				model,
				record);

			this.context.Set<EFProductModelProductDescriptionCulture>().Add(record);
			this.context.SaveChanges();
			return record.ProductModelID;
		}

		public virtual void Update(
			int productModelID,
			ProductModelProductDescriptionCultureModel model)
		{
			var record = this.SearchLinqEF(x => x.ProductModelID == productModelID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{productModelID}");
			}
			else
			{
				this.mapper.ProductModelProductDescriptionCultureMapModelToEF(
					productModelID,
					model,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int productModelID)
		{
			var record = this.SearchLinqEF(x => x.ProductModelID == productModelID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFProductModelProductDescriptionCulture>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int productModelID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.ProductModelID == productModelID, response);
			return response;
		}

		public virtual POCOProductModelProductDescriptionCulture GetByIdDirect(int productModelID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.ProductModelID == productModelID, response);
			return response.ProductModelProductDescriptionCultures.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFProductModelProductDescriptionCulture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
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

		public virtual List<POCOProductModelProductDescriptionCulture> GetWhereDirect(Expression<Func<EFProductModelProductDescriptionCulture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.ProductModelProductDescriptionCultures;
		}

		private void SearchLinqPOCO(Expression<Func<EFProductModelProductDescriptionCulture, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFProductModelProductDescriptionCulture> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.ProductModelProductDescriptionCultureMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFProductModelProductDescriptionCulture> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.ProductModelProductDescriptionCultureMapEFToPOCO(x, response));
		}

		protected virtual List<EFProductModelProductDescriptionCulture> SearchLinqEF(Expression<Func<EFProductModelProductDescriptionCulture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFProductModelProductDescriptionCulture> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>794c446a95449c4d33d97d5a672fa411</Hash>
</Codenesium>*/