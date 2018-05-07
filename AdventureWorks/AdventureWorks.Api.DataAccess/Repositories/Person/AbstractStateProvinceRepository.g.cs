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
	public abstract class AbstractStateProvinceRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractStateProvinceRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual int Create(
			StateProvinceModel model)
		{
			EFStateProvince record = new EFStateProvince();

			this.Mapper.StateProvinceMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFStateProvince>().Add(record);
			this.Context.SaveChanges();
			return record.StateProvinceID;
		}

		public virtual void Update(
			int stateProvinceID,
			StateProvinceModel model)
		{
			EFStateProvince record = this.SearchLinqEF(x => x.StateProvinceID == stateProvinceID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{stateProvinceID}");
			}
			else
			{
				this.Mapper.StateProvinceMapModelToEF(
					stateProvinceID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int stateProvinceID)
		{
			EFStateProvince record = this.SearchLinqEF(x => x.StateProvinceID == stateProvinceID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFStateProvince>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual POCOStateProvince Get(int stateProvinceID)
		{
			return this.SearchLinqPOCO(x => x.StateProvinceID == stateProvinceID).FirstOrDefault();
		}

		public virtual List<POCOStateProvince> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		private List<POCOStateProvince> Where(Expression<Func<EFStateProvince, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOStateProvince> SearchLinqPOCO(Expression<Func<EFStateProvince, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOStateProvince> response = new List<POCOStateProvince>();
			List<EFStateProvince> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.StateProvinceMapEFToPOCO(x)));
			return response;
		}

		private List<EFStateProvince> SearchLinqEF(Expression<Func<EFStateProvince, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFStateProvince>().Where(predicate).AsQueryable().OrderBy("StateProvinceID ASC").Skip(skip).Take(take).ToList<EFStateProvince>();
			}
			else
			{
				return this.Context.Set<EFStateProvince>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFStateProvince>();
			}
		}

		private List<EFStateProvince> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFStateProvince>().Where(predicate).AsQueryable().OrderBy("StateProvinceID ASC").Skip(skip).Take(take).ToList<EFStateProvince>();
			}
			else
			{
				return this.Context.Set<EFStateProvince>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFStateProvince>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>4c5d538fedf376582734d9633a17bc41</Hash>
</Codenesium>*/