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
	public abstract class AbstractProductRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractProductRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOProduct> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOProduct Get(int productID)
		{
			return this.SearchLinqPOCO(x => x.ProductID == productID).FirstOrDefault();
		}

		public virtual POCOProduct Create(
			ApiProductModel model)
		{
			Product record = new Product();

			this.Mapper.ProductMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Product>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.ProductMapEFToPOCO(record);
		}

		public virtual void Update(
			int productID,
			ApiProductModel model)
		{
			Product record = this.SearchLinqEF(x => x.ProductID == productID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{productID}");
			}
			else
			{
				this.Mapper.ProductMapModelToEF(
					productID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int productID)
		{
			Product record = this.SearchLinqEF(x => x.ProductID == productID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Product>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public POCOProduct GetName(string name)
		{
			return this.SearchLinqPOCO(x => x.Name == name).FirstOrDefault();
		}

		public POCOProduct GetProductNumber(string productNumber)
		{
			return this.SearchLinqPOCO(x => x.ProductNumber == productNumber).FirstOrDefault();
		}

		protected List<POCOProduct> Where(Expression<Func<Product, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOProduct> SearchLinqPOCO(Expression<Func<Product, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOProduct> response = new List<POCOProduct>();
			List<Product> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.ProductMapEFToPOCO(x)));
			return response;
		}

		private List<Product> SearchLinqEF(Expression<Func<Product, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Product.ProductID)} ASC";
			}
			return this.Context.Set<Product>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Product>();
		}

		private List<Product> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Product.ProductID)} ASC";
			}

			return this.Context.Set<Product>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Product>();
		}
	}
}

/*<Codenesium>
    <Hash>3bf7f42119e5d9ea3a1d127596c3e4f9</Hash>
</Codenesium>*/