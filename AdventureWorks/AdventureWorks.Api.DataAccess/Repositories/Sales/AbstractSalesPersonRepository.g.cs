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
	public abstract class AbstractSalesPersonRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractSalesPersonRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			SalesPersonModel model)
		{
			var record = new EFSalesPerson();

			this.mapper.SalesPersonMapModelToEF(
				default (int),
				model,
				record);

			this.context.Set<EFSalesPerson>().Add(record);
			this.context.SaveChanges();
			return record.BusinessEntityID;
		}

		public virtual void Update(
			int businessEntityID,
			SalesPersonModel model)
		{
			var record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{businessEntityID}");
			}
			else
			{
				this.mapper.SalesPersonMapModelToEF(
					businessEntityID,
					model,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int businessEntityID)
		{
			var record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFSalesPerson>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int businessEntityID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID, response);
			return response;
		}

		public virtual POCOSalesPerson GetByIdDirect(int businessEntityID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID, response);
			return response.SalesPersons.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFSalesPerson, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
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

		public virtual List<POCOSalesPerson> GetWhereDirect(Expression<Func<EFSalesPerson, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.SalesPersons;
		}

		private void SearchLinqPOCO(Expression<Func<EFSalesPerson, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFSalesPerson> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.SalesPersonMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFSalesPerson> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.SalesPersonMapEFToPOCO(x, response));
		}

		protected virtual List<EFSalesPerson> SearchLinqEF(Expression<Func<EFSalesPerson, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFSalesPerson> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>c9b0733e8b6919ebe7383d3c41ae6fca</Hash>
</Codenesium>*/