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
	public abstract class AbstractWorkOrderRoutingRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractWorkOrderRoutingRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			WorkOrderRoutingModel model)
		{
			var record = new EFWorkOrderRouting();

			this.mapper.WorkOrderRoutingMapModelToEF(
				default (int),
				model,
				record);

			this.context.Set<EFWorkOrderRouting>().Add(record);
			this.context.SaveChanges();
			return record.WorkOrderID;
		}

		public virtual void Update(
			int workOrderID,
			WorkOrderRoutingModel model)
		{
			var record = this.SearchLinqEF(x => x.WorkOrderID == workOrderID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{workOrderID}");
			}
			else
			{
				this.mapper.WorkOrderRoutingMapModelToEF(
					workOrderID,
					model,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int workOrderID)
		{
			var record = this.SearchLinqEF(x => x.WorkOrderID == workOrderID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFWorkOrderRouting>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int workOrderID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.WorkOrderID == workOrderID, response);
			return response;
		}

		public virtual POCOWorkOrderRouting GetByIdDirect(int workOrderID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.WorkOrderID == workOrderID, response);
			return response.WorkOrderRoutings.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFWorkOrderRouting, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
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

		public virtual List<POCOWorkOrderRouting> GetWhereDirect(Expression<Func<EFWorkOrderRouting, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.WorkOrderRoutings;
		}

		private void SearchLinqPOCO(Expression<Func<EFWorkOrderRouting, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFWorkOrderRouting> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.WorkOrderRoutingMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFWorkOrderRouting> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.WorkOrderRoutingMapEFToPOCO(x, response));
		}

		protected virtual List<EFWorkOrderRouting> SearchLinqEF(Expression<Func<EFWorkOrderRouting, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFWorkOrderRouting> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>e3a8e3810f904761d85fcce3e187d408</Hash>
</Codenesium>*/