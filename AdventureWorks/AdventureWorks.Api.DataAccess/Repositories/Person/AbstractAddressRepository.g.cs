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
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractAddressRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual int Create(
			AddressModel model)
		{
			EFAddress record = new EFAddress();

			this.Mapper.AddressMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFAddress>().Add(record);
			this.Context.SaveChanges();
			return record.AddressID;
		}

		public virtual void Update(
			int addressID,
			AddressModel model)
		{
			EFAddress record = this.SearchLinqEF(x => x.AddressID == addressID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{addressID}");
			}
			else
			{
				this.Mapper.AddressMapModelToEF(
					addressID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int addressID)
		{
			EFAddress record = this.SearchLinqEF(x => x.AddressID == addressID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFAddress>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int addressID)
		{
			return this.SearchLinqPOCO(x => x.AddressID == addressID);
		}

		public virtual POCOAddress GetByIdDirect(int addressID)
		{
			return this.SearchLinqPOCO(x => x.AddressID == addressID).Addresses.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOAddress> GetWhereDirect(Expression<Func<EFAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).Addresses;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFAddress> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.AddressMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFAddress> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.AddressMapEFToPOCO(x, response));
			return response;
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
    <Hash>fa27bc0ea9849a2b866a2da4fae3fab7</Hash>
</Codenesium>*/