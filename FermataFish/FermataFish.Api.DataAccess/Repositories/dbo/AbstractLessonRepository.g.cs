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
	public abstract class AbstractLessonRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractLessonRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOLesson> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOLesson Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOLesson Create(
			LessonModel model)
		{
			Lesson record = new Lesson();

			this.Mapper.LessonMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Lesson>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.LessonMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			LessonModel model)
		{
			Lesson record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.LessonMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			Lesson record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Lesson>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOLesson> Where(Expression<Func<Lesson, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOLesson> SearchLinqPOCO(Expression<Func<Lesson, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOLesson> response = new List<POCOLesson>();
			List<Lesson> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.LessonMapEFToPOCO(x)));
			return response;
		}

		private List<Lesson> SearchLinqEF(Expression<Func<Lesson, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Lesson.Id)} ASC";
			}
			return this.Context.Set<Lesson>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Lesson>();
		}

		private List<Lesson> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Lesson.Id)} ASC";
			}

			return this.Context.Set<Lesson>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Lesson>();
		}
	}
}

/*<Codenesium>
    <Hash>3a7ce8e2c207db9d0f08be06c5f2fe6e</Hash>
</Codenesium>*/