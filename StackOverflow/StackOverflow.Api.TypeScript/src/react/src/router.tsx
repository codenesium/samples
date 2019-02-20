import * as React from 'react';
import { Route, Switch, match, BrowserRouter } from 'react-router-dom';
import Dashboard from './components/dashboard';
import { Security, ImplicitCallback, SecureRoute } from '@okta/okta-react';
import { wrapperHeader } from './components/header';
import { ClientRoutes, Constants } from './constants';
import { WrappedBadgeCreateComponent } from './components/badge/badgeCreateForm';
import { WrappedBadgeDetailComponent } from './components/badge/badgeDetailForm';
import { WrappedBadgeEditComponent } from './components/badge/badgeEditForm';
import { WrappedBadgeSearchComponent } from './components/badge/badgeSearchForm';					
import { WrappedCommentCreateComponent } from './components/comment/commentCreateForm';
import { WrappedCommentDetailComponent } from './components/comment/commentDetailForm';
import { WrappedCommentEditComponent } from './components/comment/commentEditForm';
import { WrappedCommentSearchComponent } from './components/comment/commentSearchForm';					
import { WrappedLinkTypeCreateComponent } from './components/linkType/linkTypeCreateForm';
import { WrappedLinkTypeDetailComponent } from './components/linkType/linkTypeDetailForm';
import { WrappedLinkTypeEditComponent } from './components/linkType/linkTypeEditForm';
import { WrappedLinkTypeSearchComponent } from './components/linkType/linkTypeSearchForm';					
import { WrappedPostHistoryCreateComponent } from './components/postHistory/postHistoryCreateForm';
import { WrappedPostHistoryDetailComponent } from './components/postHistory/postHistoryDetailForm';
import { WrappedPostHistoryEditComponent } from './components/postHistory/postHistoryEditForm';
import { WrappedPostHistorySearchComponent } from './components/postHistory/postHistorySearchForm';					
import { WrappedPostHistoryTypeCreateComponent } from './components/postHistoryType/postHistoryTypeCreateForm';
import { WrappedPostHistoryTypeDetailComponent } from './components/postHistoryType/postHistoryTypeDetailForm';
import { WrappedPostHistoryTypeEditComponent } from './components/postHistoryType/postHistoryTypeEditForm';
import { WrappedPostHistoryTypeSearchComponent } from './components/postHistoryType/postHistoryTypeSearchForm';					
import { WrappedPostLinkCreateComponent } from './components/postLink/postLinkCreateForm';
import { WrappedPostLinkDetailComponent } from './components/postLink/postLinkDetailForm';
import { WrappedPostLinkEditComponent } from './components/postLink/postLinkEditForm';
import { WrappedPostLinkSearchComponent } from './components/postLink/postLinkSearchForm';					
import { WrappedPostCreateComponent } from './components/post/postCreateForm';
import { WrappedPostDetailComponent } from './components/post/postDetailForm';
import { WrappedPostEditComponent } from './components/post/postEditForm';
import { WrappedPostSearchComponent } from './components/post/postSearchForm';					
import { WrappedPostTypeCreateComponent } from './components/postType/postTypeCreateForm';
import { WrappedPostTypeDetailComponent } from './components/postType/postTypeDetailForm';
import { WrappedPostTypeEditComponent } from './components/postType/postTypeEditForm';
import { WrappedPostTypeSearchComponent } from './components/postType/postTypeSearchForm';					
import { WrappedTagCreateComponent } from './components/tag/tagCreateForm';
import { WrappedTagDetailComponent } from './components/tag/tagDetailForm';
import { WrappedTagEditComponent } from './components/tag/tagEditForm';
import { WrappedTagSearchComponent } from './components/tag/tagSearchForm';					
import { WrappedUserCreateComponent } from './components/user/userCreateForm';
import { WrappedUserDetailComponent } from './components/user/userDetailForm';
import { WrappedUserEditComponent } from './components/user/userEditForm';
import { WrappedUserSearchComponent } from './components/user/userSearchForm';					
import { WrappedVoteCreateComponent } from './components/vote/voteCreateForm';
import { WrappedVoteDetailComponent } from './components/vote/voteDetailForm';
import { WrappedVoteEditComponent } from './components/vote/voteEditForm';
import { WrappedVoteSearchComponent } from './components/vote/voteSearchForm';					
import { WrappedVoteTypeCreateComponent } from './components/voteType/voteTypeCreateForm';
import { WrappedVoteTypeDetailComponent } from './components/voteType/voteTypeDetailForm';
import { WrappedVoteTypeEditComponent } from './components/voteType/voteTypeEditForm';
import { WrappedVoteTypeSearchComponent } from './components/voteType/voteTypeSearchForm';					

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
	    <SecureRoute path="/protected" component={() => '<div>secure route</div>'} />
        <Switch>
          <Route exact path="/" component={wrapperHeader(Dashboard)} />
		  <Route path={ClientRoutes.Badges + "/create"} component={wrapperHeader(WrappedBadgeCreateComponent)} />
                      <Route path={ClientRoutes.Badges + "/edit/:id"} component={wrapperHeader(WrappedBadgeEditComponent)} />
                      <Route path={ClientRoutes.Badges + "/:id"} component={wrapperHeader(WrappedBadgeDetailComponent)} />
                      <Route path={ClientRoutes.Badges} component={wrapperHeader(WrappedBadgeSearchComponent)} />
					<Route path={ClientRoutes.Comments + "/create"} component={wrapperHeader(WrappedCommentCreateComponent)} />
                      <Route path={ClientRoutes.Comments + "/edit/:id"} component={wrapperHeader(WrappedCommentEditComponent)} />
                      <Route path={ClientRoutes.Comments + "/:id"} component={wrapperHeader(WrappedCommentDetailComponent)} />
                      <Route path={ClientRoutes.Comments} component={wrapperHeader(WrappedCommentSearchComponent)} />
					<Route path={ClientRoutes.LinkTypes + "/create"} component={wrapperHeader(WrappedLinkTypeCreateComponent)} />
                      <Route path={ClientRoutes.LinkTypes + "/edit/:id"} component={wrapperHeader(WrappedLinkTypeEditComponent)} />
                      <Route path={ClientRoutes.LinkTypes + "/:id"} component={wrapperHeader(WrappedLinkTypeDetailComponent)} />
                      <Route path={ClientRoutes.LinkTypes} component={wrapperHeader(WrappedLinkTypeSearchComponent)} />
					<Route path={ClientRoutes.PostHistories + "/create"} component={wrapperHeader(WrappedPostHistoryCreateComponent)} />
                      <Route path={ClientRoutes.PostHistories + "/edit/:id"} component={wrapperHeader(WrappedPostHistoryEditComponent)} />
                      <Route path={ClientRoutes.PostHistories + "/:id"} component={wrapperHeader(WrappedPostHistoryDetailComponent)} />
                      <Route path={ClientRoutes.PostHistories} component={wrapperHeader(WrappedPostHistorySearchComponent)} />
					<Route path={ClientRoutes.PostHistoryTypes + "/create"} component={wrapperHeader(WrappedPostHistoryTypeCreateComponent)} />
                      <Route path={ClientRoutes.PostHistoryTypes + "/edit/:id"} component={wrapperHeader(WrappedPostHistoryTypeEditComponent)} />
                      <Route path={ClientRoutes.PostHistoryTypes + "/:id"} component={wrapperHeader(WrappedPostHistoryTypeDetailComponent)} />
                      <Route path={ClientRoutes.PostHistoryTypes} component={wrapperHeader(WrappedPostHistoryTypeSearchComponent)} />
					<Route path={ClientRoutes.PostLinks + "/create"} component={wrapperHeader(WrappedPostLinkCreateComponent)} />
                      <Route path={ClientRoutes.PostLinks + "/edit/:id"} component={wrapperHeader(WrappedPostLinkEditComponent)} />
                      <Route path={ClientRoutes.PostLinks + "/:id"} component={wrapperHeader(WrappedPostLinkDetailComponent)} />
                      <Route path={ClientRoutes.PostLinks} component={wrapperHeader(WrappedPostLinkSearchComponent)} />
					<Route path={ClientRoutes.Posts + "/create"} component={wrapperHeader(WrappedPostCreateComponent)} />
                      <Route path={ClientRoutes.Posts + "/edit/:id"} component={wrapperHeader(WrappedPostEditComponent)} />
                      <Route path={ClientRoutes.Posts + "/:id"} component={wrapperHeader(WrappedPostDetailComponent)} />
                      <Route path={ClientRoutes.Posts} component={wrapperHeader(WrappedPostSearchComponent)} />
					<Route path={ClientRoutes.PostTypes + "/create"} component={wrapperHeader(WrappedPostTypeCreateComponent)} />
                      <Route path={ClientRoutes.PostTypes + "/edit/:id"} component={wrapperHeader(WrappedPostTypeEditComponent)} />
                      <Route path={ClientRoutes.PostTypes + "/:id"} component={wrapperHeader(WrappedPostTypeDetailComponent)} />
                      <Route path={ClientRoutes.PostTypes} component={wrapperHeader(WrappedPostTypeSearchComponent)} />
					<Route path={ClientRoutes.Tags + "/create"} component={wrapperHeader(WrappedTagCreateComponent)} />
                      <Route path={ClientRoutes.Tags + "/edit/:id"} component={wrapperHeader(WrappedTagEditComponent)} />
                      <Route path={ClientRoutes.Tags + "/:id"} component={wrapperHeader(WrappedTagDetailComponent)} />
                      <Route path={ClientRoutes.Tags} component={wrapperHeader(WrappedTagSearchComponent)} />
					<Route path={ClientRoutes.Users + "/create"} component={wrapperHeader(WrappedUserCreateComponent)} />
                      <Route path={ClientRoutes.Users + "/edit/:id"} component={wrapperHeader(WrappedUserEditComponent)} />
                      <Route path={ClientRoutes.Users + "/:id"} component={wrapperHeader(WrappedUserDetailComponent)} />
                      <Route path={ClientRoutes.Users} component={wrapperHeader(WrappedUserSearchComponent)} />
					<Route path={ClientRoutes.Votes + "/create"} component={wrapperHeader(WrappedVoteCreateComponent)} />
                      <Route path={ClientRoutes.Votes + "/edit/:id"} component={wrapperHeader(WrappedVoteEditComponent)} />
                      <Route path={ClientRoutes.Votes + "/:id"} component={wrapperHeader(WrappedVoteDetailComponent)} />
                      <Route path={ClientRoutes.Votes} component={wrapperHeader(WrappedVoteSearchComponent)} />
					<Route path={ClientRoutes.VoteTypes + "/create"} component={wrapperHeader(WrappedVoteTypeCreateComponent)} />
                      <Route path={ClientRoutes.VoteTypes + "/edit/:id"} component={wrapperHeader(WrappedVoteTypeEditComponent)} />
                      <Route path={ClientRoutes.VoteTypes + "/:id"} component={wrapperHeader(WrappedVoteTypeDetailComponent)} />
                      <Route path={ClientRoutes.VoteTypes} component={wrapperHeader(WrappedVoteTypeSearchComponent)} />
					        </Switch>
	  </Security>
    </BrowserRouter>
  );
}

/*<Codenesium>
    <Hash>64d468bdfd88023c6e640c5576d4ac4e</Hash>
</Codenesium>*/