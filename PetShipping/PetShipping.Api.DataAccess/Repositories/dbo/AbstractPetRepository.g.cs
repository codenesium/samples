using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public abstract class AbstractPetRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractPetRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOPet> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOPet Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOPet Create(
			PetModel model)
		{
			Pet record = new Pet();

			this.Mapper.PetMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Pet>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.PetMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			PetModel model)
		{
			Pet record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.PetMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			Pet record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Pet>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOPet> Where(Expression<Func<Pet, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOPet> SearchLinqPOCO(Expression<Func<Pet, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPet> response = new List<POCOPet>();
			List<Pet> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.PetMapEFToPOCO(x)));
			return response;
		}

		private List<Pet> SearchLinqEF(Expression<Func<Pet, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Pet.Id)} ASC";
			}
			return this.Context.Set<Pet>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Pet>();
		}

		private List<Pet> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Pet.Id)} ASC";
			}

			return this.Context.Set<Pet>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Pet>();
		}
	}
}

/*<Codenesium>
    <Hash>f31e86deb17e4bcb2cf9f0c1332a3c7a</Hash>
</Codenesium>*/