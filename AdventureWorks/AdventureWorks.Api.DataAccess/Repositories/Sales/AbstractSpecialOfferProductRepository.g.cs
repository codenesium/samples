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
	public abstract class AbstractSpecialOfferProductRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractSpecialOfferProductRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOSpecialOfferProduct> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOSpecialOfferProduct Get(int specialOfferID)
		{
			return this.SearchLinqPOCO(x => x.SpecialOfferID == specialOfferID).FirstOrDefault();
		}

		public virtual POCOSpecialOfferProduct Create(
			ApiSpecialOfferProductModel model)
		{
			SpecialOfferProduct record = new SpecialOfferProduct();

			this.Mapper.SpecialOfferProductMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<SpecialOfferProduct>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.SpecialOfferProductMapEFToPOCO(record);
		}

		public virtual void Update(
			int specialOfferID,
			ApiSpecialOfferProductModel model)
		{
			SpecialOfferProduct record = this.SearchLinqEF(x => x.SpecialOfferID == specialOfferID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{specialOfferID}");
			}
			else
			{
				this.Mapper.SpecialOfferProductMapModelToEF(
					specialOfferID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int specialOfferID)
		{
			SpecialOfferProduct record = this.SearchLinqEF(x => x.SpecialOfferID == specialOfferID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SpecialOfferProduct>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public List<POCOSpecialOfferProduct> GetProductID(int productID)
		{
			return this.SearchLinqPOCO(x => x.ProductID == productID);
		}

		protected List<POCOSpecialOfferProduct> Where(Expression<Func<SpecialOfferProduct, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOSpecialOfferProduct> SearchLinqPOCO(Expression<Func<SpecialOfferProduct, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOSpecialOfferProduct> response = new List<POCOSpecialOfferProduct>();
			List<SpecialOfferProduct> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.SpecialOfferProductMapEFToPOCO(x)));
			return response;
		}

		private List<SpecialOfferProduct> SearchLinqEF(Expression<Func<SpecialOfferProduct, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SpecialOfferProduct.SpecialOfferID)} ASC";
			}
			return this.Context.Set<SpecialOfferProduct>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<SpecialOfferProduct>();
		}

		private List<SpecialOfferProduct> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SpecialOfferProduct.SpecialOfferID)} ASC";
			}

			return this.Context.Set<SpecialOfferProduct>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<SpecialOfferProduct>();
		}
	}
}

/*<Codenesium>
    <Hash>2df241534d2e726fcaca71759d5f062c</Hash>
</Codenesium>*/