using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetStoreNS.Api.Contracts;

namespace PetStoreNS.Api.DataAccess
{
	public abstract class AbstractSpeciesRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractSpeciesRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOSpecies> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOSpecies Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOSpecies Create(
			SpeciesModel model)
		{
			Species record = new Species();

			this.Mapper.SpeciesMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Species>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.SpeciesMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			SpeciesModel model)
		{
			Species record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.SpeciesMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			Species record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Species>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOSpecies> Where(Expression<Func<Species, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOSpecies> SearchLinqPOCO(Expression<Func<Species, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOSpecies> response = new List<POCOSpecies>();
			List<Species> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.SpeciesMapEFToPOCO(x)));
			return response;
		}

		private List<Species> SearchLinqEF(Expression<Func<Species, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Species.Id)} ASC";
			}
			return this.Context.Set<Species>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Species>();
		}

		private List<Species> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Species.Id)} ASC";
			}

			return this.Context.Set<Species>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Species>();
		}
	}
}

/*<Codenesium>
    <Hash>eb914ab0288a57ea5edb0e4e88ecb07b</Hash>
</Codenesium>*/