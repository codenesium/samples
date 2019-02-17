import * as React from 'react';
import { Route, Switch, match, BrowserRouter } from 'react-router-dom';
import { App } from './app';
import Dashboard from './components/dashboard';
import { Security, ImplicitCallback, SecureRoute } from '@okta/okta-react';
import BadgeCreateComponent from './components/badge/badgeCreateForm';
import BadgeDetailComponent from './components/badge/badgeDetailForm';
import BadgeEditComponent from './components/badge/badgeEditForm';
import BadgeSearchComponent from './components/badge/badgeSearchForm';
import CommentCreateComponent from './components/comment/commentCreateForm';
import CommentDetailComponent from './components/comment/commentDetailForm';
import CommentEditComponent from './components/comment/commentEditForm';
import CommentSearchComponent from './components/comment/commentSearchForm';
import LinkTypeCreateComponent from './components/linkType/linkTypeCreateForm';
import LinkTypeDetailComponent from './components/linkType/linkTypeDetailForm';
import LinkTypeEditComponent from './components/linkType/linkTypeEditForm';
import LinkTypeSearchComponent from './components/linkType/linkTypeSearchForm';
import PostHistoryCreateComponent from './components/postHistory/postHistoryCreateForm';
import PostHistoryDetailComponent from './components/postHistory/postHistoryDetailForm';
import PostHistoryEditComponent from './components/postHistory/postHistoryEditForm';
import PostHistorySearchComponent from './components/postHistory/postHistorySearchForm';
import PostHistoryTypeCreateComponent from './components/postHistoryType/postHistoryTypeCreateForm';
import PostHistoryTypeDetailComponent from './components/postHistoryType/postHistoryTypeDetailForm';
import PostHistoryTypeEditComponent from './components/postHistoryType/postHistoryTypeEditForm';
import PostHistoryTypeSearchComponent from './components/postHistoryType/postHistoryTypeSearchForm';
import PostLinkCreateComponent from './components/postLink/postLinkCreateForm';
import PostLinkDetailComponent from './components/postLink/postLinkDetailForm';
import PostLinkEditComponent from './components/postLink/postLinkEditForm';
import PostLinkSearchComponent from './components/postLink/postLinkSearchForm';
import PostCreateComponent from './components/post/postCreateForm';
import PostDetailComponent from './components/post/postDetailForm';
import PostEditComponent from './components/post/postEditForm';
import PostSearchComponent from './components/post/postSearchForm';
import PostTypeCreateComponent from './components/postType/postTypeCreateForm';
import PostTypeDetailComponent from './components/postType/postTypeDetailForm';
import PostTypeEditComponent from './components/postType/postTypeEditForm';
import PostTypeSearchComponent from './components/postType/postTypeSearchForm';
import TagCreateComponent from './components/tag/tagCreateForm';
import TagDetailComponent from './components/tag/tagDetailForm';
import TagEditComponent from './components/tag/tagEditForm';
import TagSearchComponent from './components/tag/tagSearchForm';
import UserCreateComponent from './components/user/userCreateForm';
import UserDetailComponent from './components/user/userDetailForm';
import UserEditComponent from './components/user/userEditForm';
import UserSearchComponent from './components/user/userSearchForm';
import VoteCreateComponent from './components/vote/voteCreateForm';
import VoteDetailComponent from './components/vote/voteDetailForm';
import VoteEditComponent from './components/vote/voteEditForm';
import VoteSearchComponent from './components/vote/voteSearchForm';
import VoteTypeCreateComponent from './components/voteType/voteTypeCreateForm';
import VoteTypeDetailComponent from './components/voteType/voteTypeDetailForm';
import VoteTypeEditComponent from './components/voteType/voteTypeEditForm';
import VoteTypeSearchComponent from './components/voteType/voteTypeSearchForm';

const config = {
  oidc: {
    clientId: '<okta_client_id>',
    issuer: 'https://<okta_application_url>/oauth2/default',
    redirectUri: 'https://<your_public_webserver>/implicit/callback',
    scope: 'openid profile email',
  },
};

export const AppRouter: React.StatelessComponent<{}> = () => {
  const query = new URLSearchParams(location.search);

  return (
    <BrowserRouter>
      <Security
        issuer={config.oidc.issuer}
        client_id={config.oidc.clientId}
        redirect_uri={config.oidc.redirectUri}
      >
        <div className="container-fluid">
          <Route component={App} />
          <SecureRoute
            path="/protected"
            component={() => '<div>secure route</div>'}
          />
          <Switch>
            <Route exact path="/" component={Dashboard} />
            <Route path="/badges/create" component={BadgeCreateComponent} />
            <Route path="/badges/edit/:id" component={BadgeEditComponent} />
            <Route path="/badges/:id" component={BadgeDetailComponent} />
            <Route path="/badges" component={BadgeSearchComponent} />
            <Route path="/comments/create" component={CommentCreateComponent} />
            <Route path="/comments/edit/:id" component={CommentEditComponent} />
            <Route path="/comments/:id" component={CommentDetailComponent} />
            <Route path="/comments" component={CommentSearchComponent} />
            <Route
              path="/linktypes/create"
              component={LinkTypeCreateComponent}
            />
            <Route
              path="/linktypes/edit/:id"
              component={LinkTypeEditComponent}
            />
            <Route path="/linktypes/:id" component={LinkTypeDetailComponent} />
            <Route path="/linktypes" component={LinkTypeSearchComponent} />
            <Route
              path="/posthistories/create"
              component={PostHistoryCreateComponent}
            />
            <Route
              path="/posthistories/edit/:id"
              component={PostHistoryEditComponent}
            />
            <Route
              path="/posthistories/:id"
              component={PostHistoryDetailComponent}
            />
            <Route
              path="/posthistories"
              component={PostHistorySearchComponent}
            />
            <Route
              path="/posthistorytypes/create"
              component={PostHistoryTypeCreateComponent}
            />
            <Route
              path="/posthistorytypes/edit/:id"
              component={PostHistoryTypeEditComponent}
            />
            <Route
              path="/posthistorytypes/:id"
              component={PostHistoryTypeDetailComponent}
            />
            <Route
              path="/posthistorytypes"
              component={PostHistoryTypeSearchComponent}
            />
            <Route
              path="/postlinks/create"
              component={PostLinkCreateComponent}
            />
            <Route
              path="/postlinks/edit/:id"
              component={PostLinkEditComponent}
            />
            <Route path="/postlinks/:id" component={PostLinkDetailComponent} />
            <Route path="/postlinks" component={PostLinkSearchComponent} />
            <Route path="/posts/create" component={PostCreateComponent} />
            <Route path="/posts/edit/:id" component={PostEditComponent} />
            <Route path="/posts/:id" component={PostDetailComponent} />
            <Route path="/posts" component={PostSearchComponent} />
            <Route
              path="/posttypes/create"
              component={PostTypeCreateComponent}
            />
            <Route
              path="/posttypes/edit/:id"
              component={PostTypeEditComponent}
            />
            <Route path="/posttypes/:id" component={PostTypeDetailComponent} />
            <Route path="/posttypes" component={PostTypeSearchComponent} />
            <Route path="/tags/create" component={TagCreateComponent} />
            <Route path="/tags/edit/:id" component={TagEditComponent} />
            <Route path="/tags/:id" component={TagDetailComponent} />
            <Route path="/tags" component={TagSearchComponent} />
            <Route path="/users/create" component={UserCreateComponent} />
            <Route path="/users/edit/:id" component={UserEditComponent} />
            <Route path="/users/:id" component={UserDetailComponent} />
            <Route path="/users" component={UserSearchComponent} />
            <Route path="/votes/create" component={VoteCreateComponent} />
            <Route path="/votes/edit/:id" component={VoteEditComponent} />
            <Route path="/votes/:id" component={VoteDetailComponent} />
            <Route path="/votes" component={VoteSearchComponent} />
            <Route
              path="/votetypes/create"
              component={VoteTypeCreateComponent}
            />
            <Route
              path="/votetypes/edit/:id"
              component={VoteTypeEditComponent}
            />
            <Route path="/votetypes/:id" component={VoteTypeDetailComponent} />
            <Route path="/votetypes" component={VoteTypeSearchComponent} />
          </Switch>
        </div>
      </Security>
    </BrowserRouter>
  );
};


/*<Codenesium>
    <Hash>2037f9b4143b2ad8c1cb45d1056f86f0</Hash>
</Codenesium>*/