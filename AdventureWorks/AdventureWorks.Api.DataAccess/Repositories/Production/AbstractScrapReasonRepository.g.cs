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
	public abstract class AbstractScrapReasonRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractScrapReasonRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual short Create(
			ScrapReasonModel model)
		{
			var record = new EFScrapReason();

			this.mapper.ScrapReasonMapModelToEF(
				default (short),
				model,
				record);

			this.context.Set<EFScrapReason>().Add(record);
			this.context.SaveChanges();
			return record.ScrapReasonID;
		}

		public virtual void Update(
			short scrapReasonID,
			ScrapReasonModel model)
		{
			var record = this.SearchLinqEF(x => x.ScrapReasonID == scrapReasonID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{scrapReasonID}");
			}
			else
			{
				this.mapper.ScrapReasonMapModelToEF(
					scrapReasonID,
					model,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			short scrapReasonID)
		{
			var record = this.SearchLinqEF(x => x.ScrapReasonID == scrapReasonID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFScrapReason>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(short scrapReasonID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.ScrapReasonID == scrapReasonID, response);
			return response;
		}

		public virtual POCOScrapReason GetByIdDirect(short scrapReasonID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.ScrapReasonID == scrapReasonID, response);
			return response.ScrapReasons.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFScrapReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
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

		public virtual List<POCOScrapReason> GetWhereDirect(Expression<Func<EFScrapReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.ScrapReasons;
		}

		private void SearchLinqPOCO(Expression<Func<EFScrapReason, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFScrapReason> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.ScrapReasonMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFScrapReason> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.ScrapReasonMapEFToPOCO(x, response));
		}

		protected virtual List<EFScrapReason> SearchLinqEF(Expression<Func<EFScrapReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFScrapReason> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>7e12f07d6e2556ed1f73b70ef7cf7d52</Hash>
</Codenesium>*/