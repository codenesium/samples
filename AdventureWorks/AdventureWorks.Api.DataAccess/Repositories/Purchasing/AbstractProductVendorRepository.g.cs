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
	public abstract class AbstractProductVendorRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractProductVendorRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOProductVendor> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOProductVendor Get(int productID)
		{
			return this.SearchLinqPOCO(x => x.ProductID == productID).FirstOrDefault();
		}

		public virtual POCOProductVendor Create(
			ApiProductVendorModel model)
		{
			ProductVendor record = new ProductVendor();

			this.Mapper.ProductVendorMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<ProductVendor>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.ProductVendorMapEFToPOCO(record);
		}

		public virtual void Update(
			int productID,
			ApiProductVendorModel model)
		{
			ProductVendor record = this.SearchLinqEF(x => x.ProductID == productID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{productID}");
			}
			else
			{
				this.Mapper.ProductVendorMapModelToEF(
					productID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int productID)
		{
			ProductVendor record = this.SearchLinqEF(x => x.ProductID == productID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductVendor>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public List<POCOProductVendor> GetBusinessEntityID(int businessEntityID)
		{
			return this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID);
		}
		public List<POCOProductVendor> GetUnitMeasureCode(string unitMeasureCode)
		{
			return this.SearchLinqPOCO(x => x.UnitMeasureCode == unitMeasureCode);
		}

		protected List<POCOProductVendor> Where(Expression<Func<ProductVendor, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOProductVendor> SearchLinqPOCO(Expression<Func<ProductVendor, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOProductVendor> response = new List<POCOProductVendor>();
			List<ProductVendor> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.ProductVendorMapEFToPOCO(x)));
			return response;
		}

		private List<ProductVendor> SearchLinqEF(Expression<Func<ProductVendor, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductVendor.ProductID)} ASC";
			}
			return this.Context.Set<ProductVendor>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<ProductVendor>();
		}

		private List<ProductVendor> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductVendor.ProductID)} ASC";
			}

			return this.Context.Set<ProductVendor>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<ProductVendor>();
		}
	}
}

/*<Codenesium>
    <Hash>9d60c5748d6b95353bc0fa839b5e6745</Hash>
</Codenesium>*/