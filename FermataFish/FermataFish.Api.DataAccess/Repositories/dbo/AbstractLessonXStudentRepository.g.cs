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
	public abstract class AbstractLessonXStudentRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractLessonXStudentRepository(
			ILogger logger,
			ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			int lessonId,
			int studentId)
		{
			var record = new EFLessonXStudent();

			MapPOCOToEF(
				0,
				lessonId,
				studentId,
				record);

			this.context.Set<EFLessonXStudent>().Add(record);
			this.context.SaveChanges();
			return record.Id;
		}

		public virtual void Update(
			int id,
			int lessonId,
			int studentId)
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
					lessonId,
					studentId,
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
				this.context.Set<EFLessonXStudent>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual Response GetById(int id)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.Id == id, response);
			return response;
		}

		public virtual POCOLessonXStudent GetByIdDirect(int id)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.Id == id, response);
			return response.LessonXStudents.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFLessonXStudent, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
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

		public virtual List<POCOLessonXStudent> GetWhereDirect(Expression<Func<EFLessonXStudent, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.LessonXStudents;
		}

		private void SearchLinqPOCO(Expression<Func<EFLessonXStudent, bool>> predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFLessonXStudent> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFLessonXStudent> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		protected virtual List<EFLessonXStudent> SearchLinqEF(Expression<Func<EFLessonXStudent, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFLessonXStudent> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(
			int id,
			int lessonId,
			int studentId,
			EFLessonXStudent efLessonXStudent)
		{
			efLessonXStudent.SetProperties(lessonId.ToInt(), studentId.ToInt(), id.ToInt());
		}

		public static void MapEFToPOCO(
			EFLessonXStudent efLessonXStudent,
			Response response)
		{
			if (efLessonXStudent == null)
			{
				return;
			}

			response.AddLessonXStudent(new POCOLessonXStudent(efLessonXStudent.LessonId.ToInt(), efLessonXStudent.StudentId.ToInt(), efLessonXStudent.Id.ToInt()));

			LessonRepository.MapEFToPOCO(efLessonXStudent.Lesson, response);

			StudentRepository.MapEFToPOCO(efLessonXStudent.Student, response);
		}
	}
}

/*<Codenesium>
    <Hash>b9e45f656494f49559b5eee7f421646a</Hash>
</Codenesium>*/