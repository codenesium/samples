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
	public abstract class AbstractProductCategoryRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractProductCategoryRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual int Create(
			ProductCategoryModel model)
		{
			EFProductCategory record = new EFProductCategory();

			this.Mapper.ProductCategoryMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFProductCategory>().Add(record);
			this.Context.SaveChanges();
			return record.ProductCategoryID;
		}

		public virtual void Update(
			int productCategoryID,
			ProductCategoryModel model)
		{
			EFProductCategory record = this.SearchLinqEF(x => x.ProductCategoryID == productCategoryID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{productCategoryID}");
			}
			else
			{
				this.Mapper.ProductCategoryMapModelToEF(
					productCategoryID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int productCategoryID)
		{
			EFProductCategory record = this.SearchLinqEF(x => x.ProductCategoryID == productCategoryID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFProductCategory>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int productCategoryID)
		{
			return this.SearchLinqPOCO(x => x.ProductCategoryID == productCategoryID);
		}

		public virtual POCOProductCategory GetByIdDirect(int productCategoryID)
		{
			return this.SearchLinqPOCO(x => x.ProductCategoryID == productCategoryID).ProductCategories.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFProductCategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOProductCategory> GetWhereDirect(Expression<Func<EFProductCategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).ProductCategories;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFProductCategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFProductCategory> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.ProductCategoryMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFProductCategory> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.ProductCategoryMapEFToPOCO(x, response));
			return response;
		}

		protected virtual List<EFProductCategory> SearchLinqEF(Expression<Func<EFProductCategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFProductCategory> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>f924132918df0adb303bda2f01e2909b</Hash>
</Codenesium>*/