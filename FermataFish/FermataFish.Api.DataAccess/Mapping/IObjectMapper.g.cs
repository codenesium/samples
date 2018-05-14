using System;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.DataAccess
{
	public interface IObjectMapper
	{
		void AdminMapModelToEF(
			int id,
			AdminModel model,
			Admin efAdmin);

		POCOAdmin AdminMapEFToPOCO(
			Admin efAdmin);

		void FamilyMapModelToEF(
			int id,
			FamilyModel model,
			Family efFamily);

		POCOFamily FamilyMapEFToPOCO(
			Family efFamily);

		void LessonMapModelToEF(
			int id,
			LessonModel model,
			Lesson efLesson);

		POCOLesson LessonMapEFToPOCO(
			Lesson efLesson);

		void LessonStatusMapModelToEF(
			int id,
			LessonStatusModel model,
			LessonStatus efLessonStatus);

		POCOLessonStatus LessonStatusMapEFToPOCO(
			LessonStatus efLessonStatus);

		void LessonXStudentMapModelToEF(
			int id,
			LessonXStudentModel model,
			LessonXStudent efLessonXStudent);

		POCOLessonXStudent LessonXStudentMapEFToPOCO(
			LessonXStudent efLessonXStudent);

		void LessonXTeacherMapModelToEF(
			int id,
			LessonXTeacherModel model,
			LessonXTeacher efLessonXTeacher);

		POCOLessonXTeacher LessonXTeacherMapEFToPOCO(
			LessonXTeacher efLessonXTeacher);

		void RateMapModelToEF(
			int id,
			RateModel model,
			Rate efRate);

		POCORate RateMapEFToPOCO(
			Rate efRate);

		void SpaceMapModelToEF(
			int id,
			SpaceModel model,
			Space efSpace);

		POCOSpace SpaceMapEFToPOCO(
			Space efSpace);

		void SpaceFeatureMapModelToEF(
			int id,
			SpaceFeatureModel model,
			SpaceFeature efSpaceFeature);

		POCOSpaceFeature SpaceFeatureMapEFToPOCO(
			SpaceFeature efSpaceFeature);

		void SpaceXSpaceFeatureMapModelToEF(
			int id,
			SpaceXSpaceFeatureModel model,
			SpaceXSpaceFeature efSpaceXSpaceFeature);

		POCOSpaceXSpaceFeature SpaceXSpaceFeatureMapEFToPOCO(
			SpaceXSpaceFeature efSpaceXSpaceFeature);

		void StateMapModelToEF(
			int id,
			StateModel model,
			State efState);

		POCOState StateMapEFToPOCO(
			State efState);

		void StudentMapModelToEF(
			int id,
			StudentModel model,
			Student efStudent);

		POCOStudent StudentMapEFToPOCO(
			Student efStudent);

		void StudentXFamilyMapModelToEF(
			int id,
			StudentXFamilyModel model,
			StudentXFamily efStudentXFamily);

		POCOStudentXFamily StudentXFamilyMapEFToPOCO(
			StudentXFamily efStudentXFamily);

		void StudioMapModelToEF(
			int id,
			StudioModel model,
			Studio efStudio);

		POCOStudio StudioMapEFToPOCO(
			Studio efStudio);

		void TeacherMapModelToEF(
			int id,
			TeacherModel model,
			Teacher efTeacher);

		POCOTeacher TeacherMapEFToPOCO(
			Teacher efTeacher);

		void TeacherSkillMapModelToEF(
			int id,
			TeacherSkillModel model,
			TeacherSkill efTeacherSkill);

		POCOTeacherSkill TeacherSkillMapEFToPOCO(
			TeacherSkill efTeacherSkill);

		void TeacherXTeacherSkillMapModelToEF(
			int id,
			TeacherXTeacherSkillModel model,
			TeacherXTeacherSkill efTeacherXTeacherSkill);

		POCOTeacherXTeacherSkill TeacherXTeacherSkillMapEFToPOCO(
			TeacherXTeacherSkill efTeacherXTeacherSkill);
	}
}

/*<Codenesium>
    <Hash>cb1665dc1067f69d2d9cd1db393171eb</Hash>
</Codenesium>*/