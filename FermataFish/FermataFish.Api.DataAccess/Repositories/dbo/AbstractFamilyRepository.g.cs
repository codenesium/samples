using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public abstract class AbstractFamilyRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractFamilyRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOFamily> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOFamily Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOFamily Create(
			ApiFamilyModel model)
		{
			Family record = new Family();

			this.Mapper.FamilyMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Family>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.FamilyMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			ApiFamilyModel model)
		{
			Family record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.FamilyMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			Family record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Family>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOFamily> Where(Expression<Func<Family, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOFamily> SearchLinqPOCO(Expression<Func<Family, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOFamily> response = new List<POCOFamily>();
			List<Family> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.FamilyMapEFToPOCO(x)));
			return response;
		}

		private List<Family> SearchLinqEF(Expression<Func<Family, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Family.Id)} ASC";
			}
			return this.Context.Set<Family>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Family>();
		}

		private List<Family> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Family.Id)} ASC";
			}

			return this.Context.Set<Family>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Family>();
		}
	}
}

/*<Codenesium>
    <Hash>1932c9a0f2d97d91cb7f778523d54174</Hash>
</Codenesium>*/