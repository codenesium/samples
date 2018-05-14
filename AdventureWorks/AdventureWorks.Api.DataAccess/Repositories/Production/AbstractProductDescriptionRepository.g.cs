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
	public abstract class AbstractProductDescriptionRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractProductDescriptionRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOProductDescription> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOProductDescription Get(int productDescriptionID)
		{
			return this.SearchLinqPOCO(x => x.ProductDescriptionID == productDescriptionID).FirstOrDefault();
		}

		public virtual POCOProductDescription Create(
			ApiProductDescriptionModel model)
		{
			ProductDescription record = new ProductDescription();

			this.Mapper.ProductDescriptionMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<ProductDescription>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.ProductDescriptionMapEFToPOCO(record);
		}

		public virtual void Update(
			int productDescriptionID,
			ApiProductDescriptionModel model)
		{
			ProductDescription record = this.SearchLinqEF(x => x.ProductDescriptionID == productDescriptionID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{productDescriptionID}");
			}
			else
			{
				this.Mapper.ProductDescriptionMapModelToEF(
					productDescriptionID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int productDescriptionID)
		{
			ProductDescription record = this.SearchLinqEF(x => x.ProductDescriptionID == productDescriptionID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductDescription>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOProductDescription> Where(Expression<Func<ProductDescription, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOProductDescription> SearchLinqPOCO(Expression<Func<ProductDescription, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOProductDescription> response = new List<POCOProductDescription>();
			List<ProductDescription> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.ProductDescriptionMapEFToPOCO(x)));
			return response;
		}

		private List<ProductDescription> SearchLinqEF(Expression<Func<ProductDescription, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductDescription.ProductDescriptionID)} ASC";
			}
			return this.Context.Set<ProductDescription>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<ProductDescription>();
		}

		private List<ProductDescription> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductDescription.ProductDescriptionID)} ASC";
			}

			return this.Context.Set<ProductDescription>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<ProductDescription>();
		}
	}
}

/*<Codenesium>
    <Hash>d4be82ef6613ea24ecd4fea3f22868cd</Hash>
</Codenesium>*/