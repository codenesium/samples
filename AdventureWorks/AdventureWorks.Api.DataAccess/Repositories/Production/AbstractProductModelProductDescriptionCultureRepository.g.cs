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
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractProductModelProductDescriptionCultureRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOProductModelProductDescriptionCulture> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOProductModelProductDescriptionCulture Get(int productModelID)
		{
			return this.SearchLinqPOCO(x => x.ProductModelID == productModelID).FirstOrDefault();
		}

		public virtual POCOProductModelProductDescriptionCulture Create(
			ApiProductModelProductDescriptionCultureModel model)
		{
			ProductModelProductDescriptionCulture record = new ProductModelProductDescriptionCulture();

			this.Mapper.ProductModelProductDescriptionCultureMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<ProductModelProductDescriptionCulture>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.ProductModelProductDescriptionCultureMapEFToPOCO(record);
		}

		public virtual void Update(
			int productModelID,
			ApiProductModelProductDescriptionCultureModel model)
		{
			ProductModelProductDescriptionCulture record = this.SearchLinqEF(x => x.ProductModelID == productModelID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{productModelID}");
			}
			else
			{
				this.Mapper.ProductModelProductDescriptionCultureMapModelToEF(
					productModelID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int productModelID)
		{
			ProductModelProductDescriptionCulture record = this.SearchLinqEF(x => x.ProductModelID == productModelID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductModelProductDescriptionCulture>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOProductModelProductDescriptionCulture> Where(Expression<Func<ProductModelProductDescriptionCulture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOProductModelProductDescriptionCulture> SearchLinqPOCO(Expression<Func<ProductModelProductDescriptionCulture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOProductModelProductDescriptionCulture> response = new List<POCOProductModelProductDescriptionCulture>();
			List<ProductModelProductDescriptionCulture> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.ProductModelProductDescriptionCultureMapEFToPOCO(x)));
			return response;
		}

		private List<ProductModelProductDescriptionCulture> SearchLinqEF(Expression<Func<ProductModelProductDescriptionCulture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductModelProductDescriptionCulture.ProductModelID)} ASC";
			}
			return this.Context.Set<ProductModelProductDescriptionCulture>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<ProductModelProductDescriptionCulture>();
		}

		private List<ProductModelProductDescriptionCulture> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductModelProductDescriptionCulture.ProductModelID)} ASC";
			}

			return this.Context.Set<ProductModelProductDescriptionCulture>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<ProductModelProductDescriptionCulture>();
		}
	}
}

/*<Codenesium>
    <Hash>0431c8409e1c664e69ecb5ca00c07ef5</Hash>
</Codenesium>*/