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
	public abstract class AbstractProductSubcategoryRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractProductSubcategoryRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			ProductSubcategoryModel model)
		{
			var record = new EFProductSubcategory();

			this.mapper.ProductSubcategoryMapModelToEF(
				default (int),
				model,
				record);

			this.context.Set<EFProductSubcategory>().Add(record);
			this.context.SaveChanges();
			return record.ProductSubcategoryID;
		}

		public virtual void Update(
			int productSubcategoryID,
			ProductSubcategoryModel model)
		{
			var record = this.SearchLinqEF(x => x.ProductSubcategoryID == productSubcategoryID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{productSubcategoryID}");
			}
			else
			{
				this.mapper.ProductSubcategoryMapModelToEF(
					productSubcategoryID,
					model,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int productSubcategoryID)
		{
			var record = this.SearchLinqEF(x => x.ProductSubcategoryID == productSubcategoryID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFProductSubcategory>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int productSubcategoryID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.ProductSubcategoryID == productSubcategoryID, response);
			return response;
		}

		public virtual POCOProductSubcategory GetByIdDirect(int productSubcategoryID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.ProductSubcategoryID == productSubcategoryID, response);
			return response.ProductSubcategories.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFProductSubcategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
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

		public virtual List<POCOProductSubcategory> GetWhereDirect(Expression<Func<EFProductSubcategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.ProductSubcategories;
		}

		private void SearchLinqPOCO(Expression<Func<EFProductSubcategory, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFProductSubcategory> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.ProductSubcategoryMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFProductSubcategory> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.ProductSubcategoryMapEFToPOCO(x, response));
		}

		protected virtual List<EFProductSubcategory> SearchLinqEF(Expression<Func<EFProductSubcategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFProductSubcategory> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>01a4eb7049ba6e17fd6f6f335e03e011</Hash>
</Codenesium>*/