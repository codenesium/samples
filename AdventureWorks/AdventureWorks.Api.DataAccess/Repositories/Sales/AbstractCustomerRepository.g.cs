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
	public abstract class AbstractCustomerRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractCustomerRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOCustomer> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOCustomer Get(int customerID)
		{
			return this.SearchLinqPOCO(x => x.CustomerID == customerID).FirstOrDefault();
		}

		public virtual POCOCustomer Create(
			ApiCustomerModel model)
		{
			Customer record = new Customer();

			this.Mapper.CustomerMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Customer>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.CustomerMapEFToPOCO(record);
		}

		public virtual void Update(
			int customerID,
			ApiCustomerModel model)
		{
			Customer record = this.SearchLinqEF(x => x.CustomerID == customerID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{customerID}");
			}
			else
			{
				this.Mapper.CustomerMapModelToEF(
					customerID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int customerID)
		{
			Customer record = this.SearchLinqEF(x => x.CustomerID == customerID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Customer>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public POCOCustomer GetAccountNumber(string accountNumber)
		{
			return this.SearchLinqPOCO(x => x.AccountNumber == accountNumber).FirstOrDefault();
		}

		public List<POCOCustomer> GetTerritoryID(Nullable<int> territoryID)
		{
			return this.SearchLinqPOCO(x => x.TerritoryID == territoryID);
		}

		protected List<POCOCustomer> Where(Expression<Func<Customer, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOCustomer> SearchLinqPOCO(Expression<Func<Customer, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOCustomer> response = new List<POCOCustomer>();
			List<Customer> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.CustomerMapEFToPOCO(x)));
			return response;
		}

		private List<Customer> SearchLinqEF(Expression<Func<Customer, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Customer.CustomerID)} ASC";
			}
			return this.Context.Set<Customer>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Customer>();
		}

		private List<Customer> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Customer.CustomerID)} ASC";
			}

			return this.Context.Set<Customer>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Customer>();
		}
	}
}

/*<Codenesium>
    <Hash>29e6f55f616e8adb55cfa8c0dc60c8b4</Hash>
</Codenesium>*/