import * as React from 'react';
import { Route, Switch, match, BrowserRouter } from 'react-router-dom';
import { App } from './app';
import Dashboard from './components/dashboard';
import { Security, ImplicitCallback, SecureRoute } from '@okta/okta-react';
import AdminCreateComponent from './components/admin/adminCreateForm';
import AdminDetailComponent from './components/admin/adminDetailForm';
import AdminEditComponent from './components/admin/adminEditForm';
import AdminSearchComponent from './components/admin/adminSearchForm';					
import EventCreateComponent from './components/event/eventCreateForm';
import EventDetailComponent from './components/event/eventDetailForm';
import EventEditComponent from './components/event/eventEditForm';
import EventSearchComponent from './components/event/eventSearchForm';					
import EventStatuCreateComponent from './components/eventStatu/eventStatuCreateForm';
import EventStatuDetailComponent from './components/eventStatu/eventStatuDetailForm';
import EventStatuEditComponent from './components/eventStatu/eventStatuEditForm';
import EventStatuSearchComponent from './components/eventStatu/eventStatuSearchForm';					
import FamilyCreateComponent from './components/family/familyCreateForm';
import FamilyDetailComponent from './components/family/familyDetailForm';
import FamilyEditComponent from './components/family/familyEditForm';
import FamilySearchComponent from './components/family/familySearchForm';					
import RateCreateComponent from './components/rate/rateCreateForm';
import RateDetailComponent from './components/rate/rateDetailForm';
import RateEditComponent from './components/rate/rateEditForm';
import RateSearchComponent from './components/rate/rateSearchForm';					
import SpaceCreateComponent from './components/space/spaceCreateForm';
import SpaceDetailComponent from './components/space/spaceDetailForm';
import SpaceEditComponent from './components/space/spaceEditForm';
import SpaceSearchComponent from './components/space/spaceSearchForm';					
import SpaceFeatureCreateComponent from './components/spaceFeature/spaceFeatureCreateForm';
import SpaceFeatureDetailComponent from './components/spaceFeature/spaceFeatureDetailForm';
import SpaceFeatureEditComponent from './components/spaceFeature/spaceFeatureEditForm';
import SpaceFeatureSearchComponent from './components/spaceFeature/spaceFeatureSearchForm';					
import StudentCreateComponent from './components/student/studentCreateForm';
import StudentDetailComponent from './components/student/studentDetailForm';
import StudentEditComponent from './components/student/studentEditForm';
import StudentSearchComponent from './components/student/studentSearchForm';					
import StudioCreateComponent from './components/studio/studioCreateForm';
import StudioDetailComponent from './components/studio/studioDetailForm';
import StudioEditComponent from './components/studio/studioEditForm';
import StudioSearchComponent from './components/studio/studioSearchForm';					
import TeacherCreateComponent from './components/teacher/teacherCreateForm';
import TeacherDetailComponent from './components/teacher/teacherDetailForm';
import TeacherEditComponent from './components/teacher/teacherEditForm';
import TeacherSearchComponent from './components/teacher/teacherSearchForm';					
import TeacherSkillCreateComponent from './components/teacherSkill/teacherSkillCreateForm';
import TeacherSkillDetailComponent from './components/teacherSkill/teacherSkillDetailForm';
import TeacherSkillEditComponent from './components/teacherSkill/teacherSkillEditForm';
import TeacherSkillSearchComponent from './components/teacherSkill/teacherSkillSearchForm';					
import UserCreateComponent from './components/user/userCreateForm';
import UserDetailComponent from './components/user/userDetailForm';
import UserEditComponent from './components/user/userEditForm';
import UserSearchComponent from './components/user/userSearchForm';					

const config = {
  oidc: {
    clientId: '<okta_client_id>',
    issuer: 'https://<okta_application_url>/oauth2/default',
    redirectUri: 'https://<your_public_webserver>/implicit/callback',
    scope: 'openid profile email',
  }
}

export const AppRouter: React.StatelessComponent<{}> = () => {
  const query = new URLSearchParams(location.search)

  return (
    <BrowserRouter>   
	<Security issuer={config.oidc.issuer}
        client_id={config.oidc.clientId}
        redirect_uri={config.oidc.redirectUri}>

      <div className="container-fluid">
        <Route component={App} />
	    <SecureRoute path="/protected" component={() => '<div>secure route</div>'} />
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
										  <Route path="/eventstatus/create" component={EventStatuCreateComponent} />
					  <Route path="/eventstatus/edit/:id" component={EventStatuEditComponent} />
					  <Route path="/eventstatus/:id" component={EventStatuDetailComponent} />
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
										  <Route path="/spacefeatures/create" component={SpaceFeatureCreateComponent} />
					  <Route path="/spacefeatures/edit/:id" component={SpaceFeatureEditComponent} />
					  <Route path="/spacefeatures/:id" component={SpaceFeatureDetailComponent} />
					  <Route path="/spacefeatures" component={SpaceFeatureSearchComponent} />
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
										  <Route path="/teacherskills/create" component={TeacherSkillCreateComponent} />
					  <Route path="/teacherskills/edit/:id" component={TeacherSkillEditComponent} />
					  <Route path="/teacherskills/:id" component={TeacherSkillDetailComponent} />
					  <Route path="/teacherskills" component={TeacherSkillSearchComponent} />
										  <Route path="/users/create" component={UserCreateComponent} />
					  <Route path="/users/edit/:id" component={UserEditComponent} />
					  <Route path="/users/:id" component={UserDetailComponent} />
					  <Route path="/users" component={UserSearchComponent} />
					        </Switch>
      </div>
	  </Security>
    </BrowserRouter>
  );
}

/*<Codenesium>
    <Hash>d3b4d0f7ad86b1cab8ad40d4190f5d9a</Hash>
</Codenesium>*/