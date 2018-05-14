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

		public virtual List<POCOSalesReason> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOSalesReason Get(int salesReasonID)
		{
			return this.SearchLinqPOCO(x => x.SalesReasonID == salesReasonID).FirstOrDefault();
		}

		public virtual POCOSalesReason Create(
			ApiSalesReasonModel model)
		{
			SalesReason record = new SalesReason();

			this.Mapper.SalesReasonMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<SalesReason>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.SalesReasonMapEFToPOCO(record);
		}

		public virtual void Update(
			int salesReasonID,
			ApiSalesReasonModel model)
		{
			SalesReason record = this.SearchLinqEF(x => x.SalesReasonID == salesReasonID).FirstOrDefault();
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
			SalesReason record = this.SearchLinqEF(x => x.SalesReasonID == salesReasonID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SalesReason>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOSalesReason> Where(Expression<Func<SalesReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOSalesReason> SearchLinqPOCO(Expression<Func<SalesReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOSalesReason> response = new List<POCOSalesReason>();
			List<SalesReason> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.SalesReasonMapEFToPOCO(x)));
			return response;
		}

		private List<SalesReason> SearchLinqEF(Expression<Func<SalesReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SalesReason.SalesReasonID)} ASC";
			}
			return this.Context.Set<SalesReason>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<SalesReason>();
		}

		private List<SalesReason> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SalesReason.SalesReasonID)} ASC";
			}

			return this.Context.Set<SalesReason>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<SalesReason>();
		}
	}
}

/*<Codenesium>
    <Hash>906217da3eed60857f4f6ffb07e17cbd</Hash>
</Codenesium>*/