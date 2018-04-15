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
	public abstract class AbstractShipMethodRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractShipMethodRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			ShipMethodModel model)
		{
			var record = new EFShipMethod();

			this.mapper.ShipMethodMapModelToEF(
				default (int),
				model,
				record);

			this.context.Set<EFShipMethod>().Add(record);
			this.context.SaveChanges();
			return record.ShipMethodID;
		}

		public virtual void Update(
			int shipMethodID,
			ShipMethodModel model)
		{
			var record = this.SearchLinqEF(x => x.ShipMethodID == shipMethodID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{shipMethodID}");
			}
			else
			{
				this.mapper.ShipMethodMapModelToEF(
					shipMethodID,
					model,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int shipMethodID)
		{
			var record = this.SearchLinqEF(x => x.ShipMethodID == shipMethodID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFShipMethod>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int shipMethodID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.ShipMethodID == shipMethodID, response);
			return response;
		}

		public virtual POCOShipMethod GetByIdDirect(int shipMethodID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.ShipMethodID == shipMethodID, response);
			return response.ShipMethods.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFShipMethod, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
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

		public virtual List<POCOShipMethod> GetWhereDirect(Expression<Func<EFShipMethod, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.ShipMethods;
		}

		private void SearchLinqPOCO(Expression<Func<EFShipMethod, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFShipMethod> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.ShipMethodMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFShipMethod> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.ShipMethodMapEFToPOCO(x, response));
		}

		protected virtual List<EFShipMethod> SearchLinqEF(Expression<Func<EFShipMethod, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFShipMethod> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>26648608a6316d5128852af0d2ac37de</Hash>
</Codenesium>*/