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
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractLessonRepository(
			ILogger logger,
			ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			Nullable<DateTime> scheduledStartDate,
			Nullable<DateTime> scheduledEndDate,
			Nullable<DateTime> actualStartDate,
			Nullable<DateTime> actualEndDate,
			int lessonStatusId,
			string teacherNotes,
			string studentNotes,
			Nullable<decimal> billAmount,
			int studioId)
		{
			var record = new EFLesson();

			MapPOCOToEF(
				0,
				scheduledStartDate,
				scheduledEndDate,
				actualStartDate,
				actualEndDate,
				lessonStatusId,
				teacherNotes,
				studentNotes,
				billAmount,
				studioId,
				record);

			this.context.Set<EFLesson>().Add(record);
			this.context.SaveChanges();
			return record.Id;
		}

		public virtual void Update(
			int id,
			Nullable<DateTime> scheduledStartDate,
			Nullable<DateTime> scheduledEndDate,
			Nullable<DateTime> actualStartDate,
			Nullable<DateTime> actualEndDate,
			int lessonStatusId,
			string teacherNotes,
			string studentNotes,
			Nullable<decimal> billAmount,
			int studioId)
		{
			var record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{id}");
			}
			else
			{
				MapPOCOToEF(
					id,
					scheduledStartDate,
					scheduledEndDate,
					actualStartDate,
					actualEndDate,
					lessonStatusId,
					teacherNotes,
					studentNotes,
					billAmount,
					studioId,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			var record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFLesson>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual Response GetById(int id)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.Id == id, response);
			return response;
		}

		public virtual POCOLesson GetByIdDirect(int id)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.Id == id, response);
			return response.Lessons.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFLesson, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOLesson> GetWhereDirect(Expression<Func<EFLesson, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.Lessons;
		}

		private void SearchLinqPOCO(Expression<Func<EFLesson, bool>> predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFLesson> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFLesson> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		protected virtual List<EFLesson> SearchLinqEF(Expression<Func<EFLesson, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFLesson> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(
			int id,
			Nullable<DateTime> scheduledStartDate,
			Nullable<DateTime> scheduledEndDate,
			Nullable<DateTime> actualStartDate,
			Nullable<DateTime> actualEndDate,
			int lessonStatusId,
			string teacherNotes,
			string studentNotes,
			Nullable<decimal> billAmount,
			int studioId,
			EFLesson efLesson)
		{
			efLesson.SetProperties(id.ToInt(), scheduledStartDate.ToNullableDateTime(), scheduledEndDate.ToNullableDateTime(), actualStartDate, actualEndDate.ToNullableDateTime(), lessonStatusId.ToInt(), teacherNotes, studentNotes, billAmount, studioId.ToInt());
		}

		public static void MapEFToPOCO(
			EFLesson efLesson,
			Response response)
		{
			if (efLesson == null)
			{
				return;
			}

			response.AddLesson(new POCOLesson(efLesson.Id.ToInt(), efLesson.ScheduledStartDate.ToNullableDateTime(), efLesson.ScheduledEndDate.ToNullableDateTime(), efLesson.ActualStartDate, efLesson.ActualEndDate.ToNullableDateTime(), efLesson.LessonStatusId.ToInt(), efLesson.TeacherNotes, efLesson.StudentNotes, efLesson.BillAmount, efLesson.StudioId.ToInt()));

			LessonStatusRepository.MapEFToPOCO(efLesson.LessonStatus, response);

			StudioRepository.MapEFToPOCO(efLesson.Studio, response);
		}
	}
}

/*<Codenesium>
    <Hash>96cb3694b6351576c6c29728d0b8af30</Hash>
</Codenesium>*/