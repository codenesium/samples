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
	public abstract class AbstractLessonStatusRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractLessonStatusRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOLessonStatus> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOLessonStatus Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOLessonStatus Create(
			ApiLessonStatusModel model)
		{
			LessonStatus record = new LessonStatus();

			this.Mapper.LessonStatusMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<LessonStatus>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.LessonStatusMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			ApiLessonStatusModel model)
		{
			LessonStatus record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.LessonStatusMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			LessonStatus record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<LessonStatus>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOLessonStatus> Where(Expression<Func<LessonStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOLessonStatus> SearchLinqPOCO(Expression<Func<LessonStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOLessonStatus> response = new List<POCOLessonStatus>();
			List<LessonStatus> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.LessonStatusMapEFToPOCO(x)));
			return response;
		}

		private List<LessonStatus> SearchLinqEF(Expression<Func<LessonStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(LessonStatus.Id)} ASC";
			}
			return this.Context.Set<LessonStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<LessonStatus>();
		}

		private List<LessonStatus> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(LessonStatus.Id)} ASC";
			}

			return this.Context.Set<LessonStatus>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<LessonStatus>();
		}
	}
}

/*<Codenesium>
    <Hash>9045a677b1578bb781abe70bbfd149d5</Hash>
</Codenesium>*/