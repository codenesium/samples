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
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractSalesPersonRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual int Create(
			SalesPersonModel model)
		{
			EFSalesPerson record = new EFSalesPerson();

			this.Mapper.SalesPersonMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFSalesPerson>().Add(record);
			this.Context.SaveChanges();
			return record.BusinessEntityID;
		}

		public virtual void Update(
			int businessEntityID,
			SalesPersonModel model)
		{
			EFSalesPerson record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{businessEntityID}");
			}
			else
			{
				this.Mapper.SalesPersonMapModelToEF(
					businessEntityID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int businessEntityID)
		{
			EFSalesPerson record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFSalesPerson>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int businessEntityID)
		{
			return this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID);
		}

		public virtual POCOSalesPerson GetByIdDirect(int businessEntityID)
		{
			return this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID).SalesPersons.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFSalesPerson, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOSalesPerson> GetWhereDirect(Expression<Func<EFSalesPerson, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).SalesPersons;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFSalesPerson, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFSalesPerson> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.SalesPersonMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFSalesPerson> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.SalesPersonMapEFToPOCO(x, response));
			return response;
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
    <Hash>984bb93b943140959a7733720d17b5d2</Hash>
</Codenesium>*/