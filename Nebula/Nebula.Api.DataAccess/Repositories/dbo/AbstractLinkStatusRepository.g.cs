using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public abstract class AbstractLinkStatusRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractLinkStatusRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			LinkStatusModel model)
		{
			var record = new EFLinkStatus();

			this.mapper.LinkStatusMapModelToEF(
				default (int),
				model,
				record);

			this.context.Set<EFLinkStatus>().Add(record);
			this.context.SaveChanges();
			return record.Id;
		}

		public virtual void Update(
			int id,
			LinkStatusModel model)
		{
			var record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{id}");
			}
			else
			{
				this.mapper.LinkStatusMapModelToEF(
					id,
					model,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			var record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFLinkStatus>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int id)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.Id == id, response);
			return response;
		}

		public virtual POCOLinkStatus GetByIdDirect(int id)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.Id == id, response);
			return response.LinkStatus.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFLinkStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
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

		public virtual List<POCOLinkStatus> GetWhereDirect(Expression<Func<EFLinkStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.LinkStatus;
		}

		private void SearchLinqPOCO(Expression<Func<EFLinkStatus, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFLinkStatus> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.LinkStatusMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFLinkStatus> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.LinkStatusMapEFToPOCO(x, response));
		}

		protected virtual List<EFLinkStatus> SearchLinqEF(Expression<Func<EFLinkStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFLinkStatus> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>a14ee8d69219b8e5e6cca5b9a16f5c46</Hash>
</Codenesium>*/