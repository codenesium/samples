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
	public abstract class AbstractProductModelIllustrationRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractProductModelIllustrationRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOProductModelIllustration> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOProductModelIllustration Get(int productModelID)
		{
			return this.SearchLinqPOCO(x => x.ProductModelID == productModelID).FirstOrDefault();
		}

		public virtual POCOProductModelIllustration Create(
			ApiProductModelIllustrationModel model)
		{
			ProductModelIllustration record = new ProductModelIllustration();

			this.Mapper.ProductModelIllustrationMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<ProductModelIllustration>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.ProductModelIllustrationMapEFToPOCO(record);
		}

		public virtual void Update(
			int productModelID,
			ApiProductModelIllustrationModel model)
		{
			ProductModelIllustration record = this.SearchLinqEF(x => x.ProductModelID == productModelID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{productModelID}");
			}
			else
			{
				this.Mapper.ProductModelIllustrationMapModelToEF(
					productModelID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int productModelID)
		{
			ProductModelIllustration record = this.SearchLinqEF(x => x.ProductModelID == productModelID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductModelIllustration>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOProductModelIllustration> Where(Expression<Func<ProductModelIllustration, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOProductModelIllustration> SearchLinqPOCO(Expression<Func<ProductModelIllustration, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOProductModelIllustration> response = new List<POCOProductModelIllustration>();
			List<ProductModelIllustration> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.ProductModelIllustrationMapEFToPOCO(x)));
			return response;
		}

		private List<ProductModelIllustration> SearchLinqEF(Expression<Func<ProductModelIllustration, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductModelIllustration.ProductModelID)} ASC";
			}
			return this.Context.Set<ProductModelIllustration>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<ProductModelIllustration>();
		}

		private List<ProductModelIllustration> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductModelIllustration.ProductModelID)} ASC";
			}

			return this.Context.Set<ProductModelIllustration>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<ProductModelIllustration>();
		}
	}
}

/*<Codenesium>
    <Hash>1fe511ea4e322c8eff42748c1bc56846</Hash>
</Codenesium>*/