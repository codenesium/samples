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
	public abstract class AbstractBreedRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractBreedRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOBreed> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOBreed Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOBreed Create(
			BreedModel model)
		{
			Breed record = new Breed();

			this.Mapper.BreedMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Breed>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.BreedMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			BreedModel model)
		{
			Breed record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.BreedMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			Breed record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Breed>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOBreed> Where(Expression<Func<Breed, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOBreed> SearchLinqPOCO(Expression<Func<Breed, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOBreed> response = new List<POCOBreed>();
			List<Breed> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.BreedMapEFToPOCO(x)));
			return response;
		}

		private List<Breed> SearchLinqEF(Expression<Func<Breed, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Breed.Id)} ASC";
			}
			return this.Context.Set<Breed>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Breed>();
		}

		private List<Breed> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Breed.Id)} ASC";
			}

			return this.Context.Set<Breed>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Breed>();
		}
	}
}

/*<Codenesium>
    <Hash>eabc8e60df61cc0e4085c9cc3664ce29</Hash>
</Codenesium>*/