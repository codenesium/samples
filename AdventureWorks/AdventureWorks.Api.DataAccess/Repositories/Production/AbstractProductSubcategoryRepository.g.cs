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
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractProductSubcategoryRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual int Create(
			ProductSubcategoryModel model)
		{
			EFProductSubcategory record = new EFProductSubcategory();

			this.Mapper.ProductSubcategoryMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFProductSubcategory>().Add(record);
			this.Context.SaveChanges();
			return record.ProductSubcategoryID;
		}

		public virtual void Update(
			int productSubcategoryID,
			ProductSubcategoryModel model)
		{
			EFProductSubcategory record = this.SearchLinqEF(x => x.ProductSubcategoryID == productSubcategoryID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{productSubcategoryID}");
			}
			else
			{
				this.Mapper.ProductSubcategoryMapModelToEF(
					productSubcategoryID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int productSubcategoryID)
		{
			EFProductSubcategory record = this.SearchLinqEF(x => x.ProductSubcategoryID == productSubcategoryID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFProductSubcategory>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int productSubcategoryID)
		{
			return this.SearchLinqPOCO(x => x.ProductSubcategoryID == productSubcategoryID);
		}

		public virtual POCOProductSubcategory GetByIdDirect(int productSubcategoryID)
		{
			return this.SearchLinqPOCO(x => x.ProductSubcategoryID == productSubcategoryID).ProductSubcategories.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFProductSubcategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOProductSubcategory> GetWhereDirect(Expression<Func<EFProductSubcategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).ProductSubcategories;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFProductSubcategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFProductSubcategory> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.ProductSubcategoryMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFProductSubcategory> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.ProductSubcategoryMapEFToPOCO(x, response));
			return response;
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
    <Hash>e56a8522b7e846a11a2f097121c84fbc</Hash>
</Codenesium>*/