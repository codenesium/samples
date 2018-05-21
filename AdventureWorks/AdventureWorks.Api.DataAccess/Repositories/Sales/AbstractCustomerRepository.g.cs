using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractCustomerRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractCustomerRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOCustomer>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOCustomer> Get(int customerID)
		{
			Customer record = await this.GetById(customerID);

			return this.Mapper.CustomerMapEFToPOCO(record);
		}

		public async virtual Task<POCOCustomer> Create(
			ApiCustomerModel model)
		{
			Customer record = new Customer();

			this.Mapper.CustomerMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Customer>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.CustomerMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int customerID,
			ApiCustomerModel model)
		{
			Customer record = await this.GetById(customerID);

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

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int customerID)
		{
			Customer record = await this.GetById(customerID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Customer>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<POCOCustomer> GetAccountNumber(string accountNumber)
		{
			var records = await this.SearchLinqPOCO(x => x.AccountNumber == accountNumber);

			return records.FirstOrDefault();
		}
		public async Task<List<POCOCustomer>> GetTerritoryID(Nullable<int> territoryID)
		{
			var records = await this.SearchLinqPOCO(x => x.TerritoryID == territoryID);

			return records;
		}

		protected async Task<List<POCOCustomer>> Where(Expression<Func<Customer, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOCustomer> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOCustomer>> SearchLinqPOCO(Expression<Func<Customer, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOCustomer> response = new List<POCOCustomer>();
			List<Customer> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.CustomerMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<Customer>> SearchLinqEF(Expression<Func<Customer, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Customer.CustomerID)} ASC";
			}
			return await this.Context.Set<Customer>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Customer>();
		}

		private async Task<List<Customer>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Customer.CustomerID)} ASC";
			}

			return await this.Context.Set<Customer>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Customer>();
		}

		private async Task<Customer> GetById(int customerID)
		{
			List<Customer> records = await this.SearchLinqEF(x => x.CustomerID == customerID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>32a0d44bd44e7cf557ad19695be3760e</Hash>
</Codenesium>*/