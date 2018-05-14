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

		public virtual List<POCOIllustration> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOIllustration Get(int illustrationID)
		{
			return this.SearchLinqPOCO(x => x.IllustrationID == illustrationID).FirstOrDefault();
		}

		public virtual POCOIllustration Create(
			ApiIllustrationModel model)
		{
			Illustration record = new Illustration();

			this.Mapper.IllustrationMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Illustration>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.IllustrationMapEFToPOCO(record);
		}

		public virtual void Update(
			int illustrationID,
			ApiIllustrationModel model)
		{
			Illustration record = this.SearchLinqEF(x => x.IllustrationID == illustrationID).FirstOrDefault();
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
			Illustration record = this.SearchLinqEF(x => x.IllustrationID == illustrationID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Illustration>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOIllustration> Where(Expression<Func<Illustration, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOIllustration> SearchLinqPOCO(Expression<Func<Illustration, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOIllustration> response = new List<POCOIllustration>();
			List<Illustration> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.IllustrationMapEFToPOCO(x)));
			return response;
		}

		private List<Illustration> SearchLinqEF(Expression<Func<Illustration, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Illustration.IllustrationID)} ASC";
			}
			return this.Context.Set<Illustration>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Illustration>();
		}

		private List<Illustration> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Illustration.IllustrationID)} ASC";
			}

			return this.Context.Set<Illustration>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Illustration>();
		}
	}
}

/*<Codenesium>
    <Hash>40c47b5aa606b459835740cdd7f65150</Hash>
</Codenesium>*/