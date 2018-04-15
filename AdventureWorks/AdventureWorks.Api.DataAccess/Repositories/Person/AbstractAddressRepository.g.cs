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
	public abstract class AbstractAddressRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractAddressRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			AddressModel model)
		{
			var record = new EFAddress();

			this.mapper.AddressMapModelToEF(
				default (int),
				model,
				record);

			this.context.Set<EFAddress>().Add(record);
			this.context.SaveChanges();
			return record.AddressID;
		}

		public virtual void Update(
			int addressID,
			AddressModel model)
		{
			var record = this.SearchLinqEF(x => x.AddressID == addressID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{addressID}");
			}
			else
			{
				this.mapper.AddressMapModelToEF(
					addressID,
					model,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int addressID)
		{
			var record = this.SearchLinqEF(x => x.AddressID == addressID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFAddress>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int addressID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.AddressID == addressID, response);
			return response;
		}

		public virtual POCOAddress GetByIdDirect(int addressID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.AddressID == addressID, response);
			return response.Addresses.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
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

		public virtual List<POCOAddress> GetWhereDirect(Expression<Func<EFAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.Addresses;
		}

		private void SearchLinqPOCO(Expression<Func<EFAddress, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFAddress> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.AddressMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFAddress> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.AddressMapEFToPOCO(x, response));
		}

		protected virtual List<EFAddress> SearchLinqEF(Expression<Func<EFAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFAddress> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>71c3e186a1713b3d656c2d18efc50afc</Hash>
</Codenesium>*/