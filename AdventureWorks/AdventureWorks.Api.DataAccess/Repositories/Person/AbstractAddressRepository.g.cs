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

		public virtual POCOAddress Get(int addressID)
		{
			return this.SearchLinqPOCO(x => x.AddressID == addressID).FirstOrDefault();
		}

		public virtual List<POCOAddress> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		private List<POCOAddress> Where(Expression<Func<EFAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOAddress> SearchLinqPOCO(Expression<Func<EFAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOAddress> response = new List<POCOAddress>();
			List<EFAddress> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.AddressMapEFToPOCO(x)));
			return response;
		}

		private List<EFAddress> SearchLinqEF(Expression<Func<EFAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFAddress>().Where(predicate).AsQueryable().OrderBy("AddressID ASC").Skip(skip).Take(take).ToList<EFAddress>();
			}
			else
			{
				return this.Context.Set<EFAddress>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFAddress>();
			}
		}

		private List<EFAddress> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFAddress>().Where(predicate).AsQueryable().OrderBy("AddressID ASC").Skip(skip).Take(take).ToList<EFAddress>();
			}
			else
			{
				return this.Context.Set<EFAddress>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFAddress>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>e9634ca23179d54a7db7d8a672d63b47</Hash>
</Codenesium>*/