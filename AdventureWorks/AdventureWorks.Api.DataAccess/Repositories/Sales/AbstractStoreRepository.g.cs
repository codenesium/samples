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
	public abstract class AbstractStoreRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractStoreRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOStore> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOStore Get(int businessEntityID)
		{
			return this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
		}

		public virtual POCOStore Create(
			ApiStoreModel model)
		{
			Store record = new Store();

			this.Mapper.StoreMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Store>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.StoreMapEFToPOCO(record);
		}

		public virtual void Update(
			int businessEntityID,
			ApiStoreModel model)
		{
			Store record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{businessEntityID}");
			}
			else
			{
				this.Mapper.StoreMapModelToEF(
					businessEntityID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int businessEntityID)
		{
			Store record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Store>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public List<POCOStore> GetSalesPersonID(Nullable<int> salesPersonID)
		{
			return this.SearchLinqPOCO(x => x.SalesPersonID == salesPersonID);
		}
		public List<POCOStore> GetDemographics(string demographics)
		{
			return this.SearchLinqPOCO(x => x.Demographics == demographics);
		}

		protected List<POCOStore> Where(Expression<Func<Store, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOStore> SearchLinqPOCO(Expression<Func<Store, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOStore> response = new List<POCOStore>();
			List<Store> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.StoreMapEFToPOCO(x)));
			return response;
		}

		private List<Store> SearchLinqEF(Expression<Func<Store, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Store.BusinessEntityID)} ASC";
			}
			return this.Context.Set<Store>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Store>();
		}

		private List<Store> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Store.BusinessEntityID)} ASC";
			}

			return this.Context.Set<Store>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Store>();
		}
	}
}

/*<Codenesium>
    <Hash>49b9dbf292130c104a5eb17e500245c4</Hash>
</Codenesium>*/