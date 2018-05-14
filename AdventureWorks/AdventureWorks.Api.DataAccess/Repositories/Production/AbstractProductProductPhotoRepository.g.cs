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
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractProductProductPhotoRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOProductProductPhoto> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOProductProductPhoto Get(int productID)
		{
			return this.SearchLinqPOCO(x => x.ProductID == productID).FirstOrDefault();
		}

		public virtual POCOProductProductPhoto Create(
			ApiProductProductPhotoModel model)
		{
			ProductProductPhoto record = new ProductProductPhoto();

			this.Mapper.ProductProductPhotoMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<ProductProductPhoto>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.ProductProductPhotoMapEFToPOCO(record);
		}

		public virtual void Update(
			int productID,
			ApiProductProductPhotoModel model)
		{
			ProductProductPhoto record = this.SearchLinqEF(x => x.ProductID == productID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{productID}");
			}
			else
			{
				this.Mapper.ProductProductPhotoMapModelToEF(
					productID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int productID)
		{
			ProductProductPhoto record = this.SearchLinqEF(x => x.ProductID == productID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductProductPhoto>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOProductProductPhoto> Where(Expression<Func<ProductProductPhoto, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOProductProductPhoto> SearchLinqPOCO(Expression<Func<ProductProductPhoto, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOProductProductPhoto> response = new List<POCOProductProductPhoto>();
			List<ProductProductPhoto> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.ProductProductPhotoMapEFToPOCO(x)));
			return response;
		}

		private List<ProductProductPhoto> SearchLinqEF(Expression<Func<ProductProductPhoto, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductProductPhoto.ProductID)} ASC";
			}
			return this.Context.Set<ProductProductPhoto>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<ProductProductPhoto>();
		}

		private List<ProductProductPhoto> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductProductPhoto.ProductID)} ASC";
			}

			return this.Context.Set<ProductProductPhoto>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<ProductProductPhoto>();
		}
	}
}

/*<Codenesium>
    <Hash>e6d9b66f1bbbe2408ceaa07247586900</Hash>
</Codenesium>*/