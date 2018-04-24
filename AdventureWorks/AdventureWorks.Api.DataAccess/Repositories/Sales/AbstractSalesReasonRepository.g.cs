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
	public abstract class AbstractSalesReasonRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractSalesReasonRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual int Create(
			SalesReasonModel model)
		{
			EFSalesReason record = new EFSalesReason();

			this.Mapper.SalesReasonMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFSalesReason>().Add(record);
			this.Context.SaveChanges();
			return record.SalesReasonID;
		}

		public virtual void Update(
			int salesReasonID,
			SalesReasonModel model)
		{
			EFSalesReason record = this.SearchLinqEF(x => x.SalesReasonID == salesReasonID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{salesReasonID}");
			}
			else
			{
				this.Mapper.SalesReasonMapModelToEF(
					salesReasonID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int salesReasonID)
		{
			EFSalesReason record = this.SearchLinqEF(x => x.SalesReasonID == salesReasonID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFSalesReason>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int salesReasonID)
		{
			return this.SearchLinqPOCO(x => x.SalesReasonID == salesReasonID);
		}

		public virtual POCOSalesReason GetByIdDirect(int salesReasonID)
		{
			return this.SearchLinqPOCO(x => x.SalesReasonID == salesReasonID).SalesReasons.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFSalesReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOSalesReason> GetWhereDirect(Expression<Func<EFSalesReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).SalesReasons;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFSalesReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFSalesReason> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.SalesReasonMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFSalesReason> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.SalesReasonMapEFToPOCO(x, response));
			return response;
		}

		protected virtual List<EFSalesReason> SearchLinqEF(Expression<Func<EFSalesReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFSalesReason> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>5f38484fe2edabef151f0431b30b8e9a</Hash>
</Codenesium>*/