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
	public abstract class AbstractProductPhotoRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractProductPhotoRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOProductPhoto> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOProductPhoto Get(int productPhotoID)
		{
			return this.SearchLinqPOCO(x => x.ProductPhotoID == productPhotoID).FirstOrDefault();
		}

		public virtual POCOProductPhoto Create(
			ApiProductPhotoModel model)
		{
			ProductPhoto record = new ProductPhoto();

			this.Mapper.ProductPhotoMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<ProductPhoto>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.ProductPhotoMapEFToPOCO(record);
		}

		public virtual void Update(
			int productPhotoID,
			ApiProductPhotoModel model)
		{
			ProductPhoto record = this.SearchLinqEF(x => x.ProductPhotoID == productPhotoID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{productPhotoID}");
			}
			else
			{
				this.Mapper.ProductPhotoMapModelToEF(
					productPhotoID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int productPhotoID)
		{
			ProductPhoto record = this.SearchLinqEF(x => x.ProductPhotoID == productPhotoID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductPhoto>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOProductPhoto> Where(Expression<Func<ProductPhoto, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOProductPhoto> SearchLinqPOCO(Expression<Func<ProductPhoto, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOProductPhoto> response = new List<POCOProductPhoto>();
			List<ProductPhoto> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.ProductPhotoMapEFToPOCO(x)));
			return response;
		}

		private List<ProductPhoto> SearchLinqEF(Expression<Func<ProductPhoto, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductPhoto.ProductPhotoID)} ASC";
			}
			return this.Context.Set<ProductPhoto>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<ProductPhoto>();
		}

		private List<ProductPhoto> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductPhoto.ProductPhotoID)} ASC";
			}

			return this.Context.Set<ProductPhoto>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<ProductPhoto>();
		}
	}
}

/*<Codenesium>
    <Hash>92829e8a472363500ed68005ce730815</Hash>
</Codenesium>*/