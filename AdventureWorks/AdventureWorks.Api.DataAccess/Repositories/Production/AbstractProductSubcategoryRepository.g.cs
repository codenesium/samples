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

		public virtual POCOProductSubcategory Get(int productSubcategoryID)
		{
			return this.SearchLinqPOCO(x => x.ProductSubcategoryID == productSubcategoryID).FirstOrDefault();
		}

		public virtual List<POCOProductSubcategory> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		private List<POCOProductSubcategory> Where(Expression<Func<EFProductSubcategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOProductSubcategory> SearchLinqPOCO(Expression<Func<EFProductSubcategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOProductSubcategory> response = new List<POCOProductSubcategory>();
			List<EFProductSubcategory> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.ProductSubcategoryMapEFToPOCO(x)));
			return response;
		}

		private List<EFProductSubcategory> SearchLinqEF(Expression<Func<EFProductSubcategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFProductSubcategory>().Where(predicate).AsQueryable().OrderBy("ProductSubcategoryID ASC").Skip(skip).Take(take).ToList<EFProductSubcategory>();
			}
			else
			{
				return this.Context.Set<EFProductSubcategory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductSubcategory>();
			}
		}

		private List<EFProductSubcategory> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFProductSubcategory>().Where(predicate).AsQueryable().OrderBy("ProductSubcategoryID ASC").Skip(skip).Take(take).ToList<EFProductSubcategory>();
			}
			else
			{
				return this.Context.Set<EFProductSubcategory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFProductSubcategory>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>47c42b79fb0401a19bf988612e869587</Hash>
</Codenesium>*/