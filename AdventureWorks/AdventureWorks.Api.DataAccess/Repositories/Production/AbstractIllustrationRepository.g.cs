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
	public abstract class AbstractIllustrationRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractIllustrationRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual int Create(
			IllustrationModel model)
		{
			EFIllustration record = new EFIllustration();

			this.Mapper.IllustrationMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFIllustration>().Add(record);
			this.Context.SaveChanges();
			return record.IllustrationID;
		}

		public virtual void Update(
			int illustrationID,
			IllustrationModel model)
		{
			EFIllustration record = this.SearchLinqEF(x => x.IllustrationID == illustrationID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{illustrationID}");
			}
			else
			{
				this.Mapper.IllustrationMapModelToEF(
					illustrationID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int illustrationID)
		{
			EFIllustration record = this.SearchLinqEF(x => x.IllustrationID == illustrationID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFIllustration>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual POCOIllustration Get(int illustrationID)
		{
			return this.SearchLinqPOCO(x => x.IllustrationID == illustrationID).FirstOrDefault();
		}

		public virtual List<POCOIllustration> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		private List<POCOIllustration> Where(Expression<Func<EFIllustration, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOIllustration> SearchLinqPOCO(Expression<Func<EFIllustration, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOIllustration> response = new List<POCOIllustration>();
			List<EFIllustration> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.IllustrationMapEFToPOCO(x)));
			return response;
		}

		private List<EFIllustration> SearchLinqEF(Expression<Func<EFIllustration, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFIllustration>().Where(predicate).AsQueryable().OrderBy("IllustrationID ASC").Skip(skip).Take(take).ToList<EFIllustration>();
			}
			else
			{
				return this.Context.Set<EFIllustration>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFIllustration>();
			}
		}

		private List<EFIllustration> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFIllustration>().Where(predicate).AsQueryable().OrderBy("IllustrationID ASC").Skip(skip).Take(take).ToList<EFIllustration>();
			}
			else
			{
				return this.Context.Set<EFIllustration>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFIllustration>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>093c9a36ce49ac6413011526ec123981</Hash>
</Codenesium>*/