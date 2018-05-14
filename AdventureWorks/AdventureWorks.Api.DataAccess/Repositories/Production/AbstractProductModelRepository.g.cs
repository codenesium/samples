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
	public abstract class AbstractProductModelRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractProductModelRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOProductModel> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOProductModel Get(int productModelID)
		{
			return this.SearchLinqPOCO(x => x.ProductModelID == productModelID).FirstOrDefault();
		}

		public virtual POCOProductModel Create(
			ApiProductModelModel model)
		{
			ProductModel record = new ProductModel();

			this.Mapper.ProductModelMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<ProductModel>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.ProductModelMapEFToPOCO(record);
		}

		public virtual void Update(
			int productModelID,
			ApiProductModelModel model)
		{
			ProductModel record = this.SearchLinqEF(x => x.ProductModelID == productModelID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{productModelID}");
			}
			else
			{
				this.Mapper.ProductModelMapModelToEF(
					productModelID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int productModelID)
		{
			ProductModel record = this.SearchLinqEF(x => x.ProductModelID == productModelID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductModel>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public POCOProductModel GetName(string name)
		{
			return this.SearchLinqPOCO(x => x.Name == name).FirstOrDefault();
		}

		public List<POCOProductModel> GetCatalogDescription(string catalogDescription)
		{
			return this.SearchLinqPOCO(x => x.CatalogDescription == catalogDescription);
		}
		public List<POCOProductModel> GetInstructions(string instructions)
		{
			return this.SearchLinqPOCO(x => x.Instructions == instructions);
		}

		protected List<POCOProductModel> Where(Expression<Func<ProductModel, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOProductModel> SearchLinqPOCO(Expression<Func<ProductModel, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOProductModel> response = new List<POCOProductModel>();
			List<ProductModel> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.ProductModelMapEFToPOCO(x)));
			return response;
		}

		private List<ProductModel> SearchLinqEF(Expression<Func<ProductModel, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductModel.ProductModelID)} ASC";
			}
			return this.Context.Set<ProductModel>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<ProductModel>();
		}

		private List<ProductModel> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductModel.ProductModelID)} ASC";
			}

			return this.Context.Set<ProductModel>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<ProductModel>();
		}
	}
}

/*<Codenesium>
    <Hash>e2b7a051b066e9e20e02257b2fed20d5</Hash>
</Codenesium>*/