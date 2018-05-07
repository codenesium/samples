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

		public virtual int Create(
			CustomerModel model)
		{
			EFCustomer record = new EFCustomer();

			this.Mapper.CustomerMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFCustomer>().Add(record);
			this.Context.SaveChanges();
			return record.CustomerID;
		}

		public virtual void Update(
			int customerID,
			CustomerModel model)
		{
			EFCustomer record = this.SearchLinqEF(x => x.CustomerID == customerID).FirstOrDefault();
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
			EFCustomer record = this.SearchLinqEF(x => x.CustomerID == customerID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFCustomer>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual POCOCustomer Get(int customerID)
		{
			return this.SearchLinqPOCO(x => x.CustomerID == customerID).FirstOrDefault();
		}

		public virtual List<POCOCustomer> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		private List<POCOCustomer> Where(Expression<Func<EFCustomer, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOCustomer> SearchLinqPOCO(Expression<Func<EFCustomer, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOCustomer> response = new List<POCOCustomer>();
			List<EFCustomer> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.CustomerMapEFToPOCO(x)));
			return response;
		}

		private List<EFCustomer> SearchLinqEF(Expression<Func<EFCustomer, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFCustomer>().Where(predicate).AsQueryable().OrderBy("CustomerID ASC").Skip(skip).Take(take).ToList<EFCustomer>();
			}
			else
			{
				return this.Context.Set<EFCustomer>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFCustomer>();
			}
		}

		private List<EFCustomer> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFCustomer>().Where(predicate).AsQueryable().OrderBy("CustomerID ASC").Skip(skip).Take(take).ToList<EFCustomer>();
			}
			else
			{
				return this.Context.Set<EFCustomer>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFCustomer>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>7f06e59cd4c67dec256a2fcc95fc9aab</Hash>
</Codenesium>*/