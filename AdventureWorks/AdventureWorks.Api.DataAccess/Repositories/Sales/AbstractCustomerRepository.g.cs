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
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractCustomerRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			CustomerModel model)
		{
			var record = new EFCustomer();

			this.mapper.CustomerMapModelToEF(
				default (int),
				model,
				record);

			this.context.Set<EFCustomer>().Add(record);
			this.context.SaveChanges();
			return record.CustomerID;
		}

		public virtual void Update(
			int customerID,
			CustomerModel model)
		{
			var record = this.SearchLinqEF(x => x.CustomerID == customerID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{customerID}");
			}
			else
			{
				this.mapper.CustomerMapModelToEF(
					customerID,
					model,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int customerID)
		{
			var record = this.SearchLinqEF(x => x.CustomerID == customerID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFCustomer>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int customerID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.CustomerID == customerID, response);
			return response;
		}

		public virtual POCOCustomer GetByIdDirect(int customerID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.CustomerID == customerID, response);
			return response.Customers.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFCustomer, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOCustomer> GetWhereDirect(Expression<Func<EFCustomer, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.Customers;
		}

		private void SearchLinqPOCO(Expression<Func<EFCustomer, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFCustomer> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.CustomerMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFCustomer> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.CustomerMapEFToPOCO(x, response));
		}

		protected virtual List<EFCustomer> SearchLinqEF(Expression<Func<EFCustomer, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFCustomer> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>bae8ef49eaa4c8b92bec310516ab94cf</Hash>
</Codenesium>*/