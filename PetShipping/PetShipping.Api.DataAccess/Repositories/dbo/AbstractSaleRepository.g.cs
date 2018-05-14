using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public abstract class AbstractSaleRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractSaleRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOSale> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOSale Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOSale Create(
			ApiSaleModel model)
		{
			Sale record = new Sale();

			this.Mapper.SaleMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Sale>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.SaleMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			ApiSaleModel model)
		{
			Sale record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.SaleMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			Sale record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Sale>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOSale> Where(Expression<Func<Sale, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOSale> SearchLinqPOCO(Expression<Func<Sale, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOSale> response = new List<POCOSale>();
			List<Sale> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.SaleMapEFToPOCO(x)));
			return response;
		}

		private List<Sale> SearchLinqEF(Expression<Func<Sale, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Sale.Id)} ASC";
			}
			return this.Context.Set<Sale>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Sale>();
		}

		private List<Sale> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Sale.Id)} ASC";
			}

			return this.Context.Set<Sale>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Sale>();
		}
	}
}

/*<Codenesium>
    <Hash>786bcfcfed5d18ce3b47133c1c9018cd</Hash>
</Codenesium>*/