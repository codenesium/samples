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
	public abstract class AbstractSpaceRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractSpaceRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOSpace> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOSpace Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOSpace Create(
			SpaceModel model)
		{
			Space record = new Space();

			this.Mapper.SpaceMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Space>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.SpaceMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			SpaceModel model)
		{
			Space record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.SpaceMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			Space record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Space>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOSpace> Where(Expression<Func<Space, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOSpace> SearchLinqPOCO(Expression<Func<Space, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOSpace> response = new List<POCOSpace>();
			List<Space> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.SpaceMapEFToPOCO(x)));
			return response;
		}

		private List<Space> SearchLinqEF(Expression<Func<Space, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Space.Id)} ASC";
			}
			return this.Context.Set<Space>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Space>();
		}

		private List<Space> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Space.Id)} ASC";
			}

			return this.Context.Set<Space>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Space>();
		}
	}
}

/*<Codenesium>
    <Hash>3a08f4a7130a79003b8553f948e858a1</Hash>
</Codenesium>*/