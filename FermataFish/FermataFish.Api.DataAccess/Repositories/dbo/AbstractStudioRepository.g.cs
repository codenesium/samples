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
	public abstract class AbstractStudioRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractStudioRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOStudio> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOStudio Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOStudio Create(
			StudioModel model)
		{
			Studio record = new Studio();

			this.Mapper.StudioMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Studio>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.StudioMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			StudioModel model)
		{
			Studio record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.StudioMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			Studio record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Studio>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOStudio> Where(Expression<Func<Studio, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOStudio> SearchLinqPOCO(Expression<Func<Studio, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOStudio> response = new List<POCOStudio>();
			List<Studio> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.StudioMapEFToPOCO(x)));
			return response;
		}

		private List<Studio> SearchLinqEF(Expression<Func<Studio, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Studio.Id)} ASC";
			}
			return this.Context.Set<Studio>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Studio>();
		}

		private List<Studio> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Studio.Id)} ASC";
			}

			return this.Context.Set<Studio>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Studio>();
		}
	}
}

/*<Codenesium>
    <Hash>9cd2b5d4abdfeb6e37758fcdb244af8d</Hash>
</Codenesium>*/