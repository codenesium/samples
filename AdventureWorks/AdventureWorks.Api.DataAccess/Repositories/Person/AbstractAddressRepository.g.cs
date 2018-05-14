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

		public virtual List<POCOAddress> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOAddress Get(int addressID)
		{
			return this.SearchLinqPOCO(x => x.AddressID == addressID).FirstOrDefault();
		}

		public virtual POCOAddress Create(
			ApiAddressModel model)
		{
			Address record = new Address();

			this.Mapper.AddressMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Address>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.AddressMapEFToPOCO(record);
		}

		public virtual void Update(
			int addressID,
			ApiAddressModel model)
		{
			Address record = this.SearchLinqEF(x => x.AddressID == addressID).FirstOrDefault();
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
			Address record = this.SearchLinqEF(x => x.AddressID == addressID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Address>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public POCOAddress GetAddressLine1AddressLine2CityStateProvinceIDPostalCode(string addressLine1,string addressLine2,string city,int stateProvinceID,string postalCode)
		{
			return this.SearchLinqPOCO(x => x.AddressLine1 == addressLine1 && x.AddressLine2 == addressLine2 && x.City == city && x.StateProvinceID == stateProvinceID && x.PostalCode == postalCode).FirstOrDefault();
		}

		public List<POCOAddress> GetStateProvinceID(int stateProvinceID)
		{
			return this.SearchLinqPOCO(x => x.StateProvinceID == stateProvinceID);
		}

		protected List<POCOAddress> Where(Expression<Func<Address, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOAddress> SearchLinqPOCO(Expression<Func<Address, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOAddress> response = new List<POCOAddress>();
			List<Address> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.AddressMapEFToPOCO(x)));
			return response;
		}

		private List<Address> SearchLinqEF(Expression<Func<Address, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Address.AddressID)} ASC";
			}
			return this.Context.Set<Address>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Address>();
		}

		private List<Address> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Address.AddressID)} ASC";
			}

			return this.Context.Set<Address>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Address>();
		}
	}
}

/*<Codenesium>
    <Hash>3da6720eb1d8d503f0c575cd25afe4ff</Hash>
</Codenesium>*/