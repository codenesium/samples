import * as React from 'react';
import { Route, Switch, match, BrowserRouter } from 'react-router-dom';
import { App } from './app';
import { Dashboard } from './components/dashboard';
import AdminCreateComponent from './components/adminCreateForm';
import AdminDetailComponent from './components/adminDetailForm';
import AdminEditComponent from './components/adminEditForm';
import AdminSearchComponent from './components/adminSearchForm';
import EventCreateComponent from './components/eventCreateForm';
import EventDetailComponent from './components/eventDetailForm';
import EventEditComponent from './components/eventEditForm';
import EventSearchComponent from './components/eventSearchForm';
import EventStatuCreateComponent from './components/eventStatuCreateForm';
import EventStatuDetailComponent from './components/eventStatuDetailForm';
import EventStatuEditComponent from './components/eventStatuEditForm';
import EventStatuSearchComponent from './components/eventStatuSearchForm';
import FamilyCreateComponent from './components/familyCreateForm';
import FamilyDetailComponent from './components/familyDetailForm';
import FamilyEditComponent from './components/familyEditForm';
import FamilySearchComponent from './components/familySearchForm';
import RateCreateComponent from './components/rateCreateForm';
import RateDetailComponent from './components/rateDetailForm';
import RateEditComponent from './components/rateEditForm';
import RateSearchComponent from './components/rateSearchForm';
import SpaceCreateComponent from './components/spaceCreateForm';
import SpaceDetailComponent from './components/spaceDetailForm';
import SpaceEditComponent from './components/spaceEditForm';
import SpaceSearchComponent from './components/spaceSearchForm';
import SpaceFeatureCreateComponent from './components/spaceFeatureCreateForm';
import SpaceFeatureDetailComponent from './components/spaceFeatureDetailForm';
import SpaceFeatureEditComponent from './components/spaceFeatureEditForm';
import SpaceFeatureSearchComponent from './components/spaceFeatureSearchForm';
import StudentCreateComponent from './components/studentCreateForm';
import StudentDetailComponent from './components/studentDetailForm';
import StudentEditComponent from './components/studentEditForm';
import StudentSearchComponent from './components/studentSearchForm';
import StudioCreateComponent from './components/studioCreateForm';
import StudioDetailComponent from './components/studioDetailForm';
import StudioEditComponent from './components/studioEditForm';
import StudioSearchComponent from './components/studioSearchForm';
import TeacherCreateComponent from './components/teacherCreateForm';
import TeacherDetailComponent from './components/teacherDetailForm';
import TeacherEditComponent from './components/teacherEditForm';
import TeacherSearchComponent from './components/teacherSearchForm';
import TeacherSkillCreateComponent from './components/teacherSkillCreateForm';
import TeacherSkillDetailComponent from './components/teacherSkillDetailForm';
import TeacherSkillEditComponent from './components/teacherSkillEditForm';
import TeacherSkillSearchComponent from './components/teacherSkillSearchForm';
import UserCreateComponent from './components/userCreateForm';
import UserDetailComponent from './components/userDetailForm';
import UserEditComponent from './components/userEditForm';
import UserSearchComponent from './components/userSearchForm';

export const AppRouter: React.StatelessComponent<{}> = () => {
  const query = new URLSearchParams(location.search);

  return (
    <BrowserRouter>
      <div className="container-fluid">
        <Route component={App} />
        <Switch>
          <Route exact path="/" component={Dashboard} />
          <Route path="/admins/create" component={AdminCreateComponent} />
          <Route path="/admins/edit/:id" component={AdminEditComponent} />
          <Route path="/admins/:id" component={AdminDetailComponent} />
          <Route path="/admins" component={AdminSearchComponent} />
          <Route path="/events/create" component={EventCreateComponent} />
          <Route path="/events/edit/:id" component={EventEditComponent} />
          <Route path="/events/:id" component={EventDetailComponent} />
          <Route path="/events" component={EventSearchComponent} />
          <Route
            path="/eventstatus/create"
            component={EventStatuCreateComponent}
          />
          <Route
            path="/eventstatus/edit/:id"
            component={EventStatuEditComponent}
          />
          <Route
            path="/eventstatus/:id"
            component={EventStatuDetailComponent}
          />
          <Route path="/eventstatus" component={EventStatuSearchComponent} />
          <Route path="/families/create" component={FamilyCreateComponent} />
          <Route path="/families/edit/:id" component={FamilyEditComponent} />
          <Route path="/families/:id" component={FamilyDetailComponent} />
          <Route path="/families" component={FamilySearchComponent} />
          <Route path="/rates/create" component={RateCreateComponent} />
          <Route path="/rates/edit/:id" component={RateEditComponent} />
          <Route path="/rates/:id" component={RateDetailComponent} />
          <Route path="/rates" component={RateSearchComponent} />
          <Route path="/spaces/create" component={SpaceCreateComponent} />
          <Route path="/spaces/edit/:id" component={SpaceEditComponent} />
          <Route path="/spaces/:id" component={SpaceDetailComponent} />
          <Route path="/spaces" component={SpaceSearchComponent} />
          <Route
            path="/spacefeatures/create"
            component={SpaceFeatureCreateComponent}
          />
          <Route
            path="/spacefeatures/edit/:id"
            component={SpaceFeatureEditComponent}
          />
          <Route
            path="/spacefeatures/:id"
            component={SpaceFeatureDetailComponent}
          />
          <Route
            path="/spacefeatures"
            component={SpaceFeatureSearchComponent}
          />
          <Route path="/students/create" component={StudentCreateComponent} />
          <Route path="/students/edit/:id" component={StudentEditComponent} />
          <Route path="/students/:id" component={StudentDetailComponent} />
          <Route path="/students" component={StudentSearchComponent} />
          <Route path="/studios/create" component={StudioCreateComponent} />
          <Route path="/studios/edit/:id" component={StudioEditComponent} />
          <Route path="/studios/:id" component={StudioDetailComponent} />
          <Route path="/studios" component={StudioSearchComponent} />
          <Route path="/teachers/create" component={TeacherCreateComponent} />
          <Route path="/teachers/edit/:id" component={TeacherEditComponent} />
          <Route path="/teachers/:id" component={TeacherDetailComponent} />
          <Route path="/teachers" component={TeacherSearchComponent} />
          <Route
            path="/teacherskills/create"
            component={TeacherSkillCreateComponent}
          />
          <Route
            path="/teacherskills/edit/:id"
            component={TeacherSkillEditComponent}
          />
          <Route
            path="/teacherskills/:id"
            component={TeacherSkillDetailComponent}
          />
          <Route
            path="/teacherskills"
            component={TeacherSkillSearchComponent}
          />
          <Route path="/users/create" component={UserCreateComponent} />
          <Route path="/users/edit/:id" component={UserEditComponent} />
          <Route path="/users/:id" component={UserDetailComponent} />
          <Route path="/users" component={UserSearchComponent} />
        </Switch>
      </div>
    </BrowserRouter>
  );
};


/*<Codenesium>
    <Hash>188a660a530a994b8ca550bff4406ea5</Hash>
</Codenesium>*/