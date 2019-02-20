import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { LoadingForm } from '../../lib/components/loadingForm';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PostMapper from './postMapper';
import PostViewModel from './postViewModel';
import { Form, Input, Button } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { Alert } from 'antd';

interface PostDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface PostDetailComponentState {
  model?: PostViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class PostDetailComponent extends React.Component<
  PostDetailComponentProps,
  PostDetailComponentState
> {
  state = {
    model: new PostViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Posts + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Posts +
          '/' +
          this.props.match.params.id,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.PostClientResponseModel;

          console.log(response);

          let mapper = new PostMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }

  render() {
    let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    }

    if (this.state.loading) {
      return <LoadingForm />;
    } else if (this.state.loaded) {
      return (
        <div>
          <Button
            style={{ float: 'right' }}
            type="primary"
            onClick={(e: any) => {
              this.handleEditClick(e);
            }}
          >
            <i className="fas fa-edit" />
          </Button>
          <div>
            <div>
              <div>acceptedAnswerId</div>
              <div>{this.state.model!.acceptedAnswerId}</div>
            </div>
            <div>
              <div>answerCount</div>
              <div>{this.state.model!.answerCount}</div>
            </div>
            <div>
              <div>body</div>
              <div>{this.state.model!.body}</div>
            </div>
            <div>
              <div>closedDate</div>
              <div>{this.state.model!.closedDate}</div>
            </div>
            <div>
              <div>commentCount</div>
              <div>{this.state.model!.commentCount}</div>
            </div>
            <div>
              <div>communityOwnedDate</div>
              <div>{this.state.model!.communityOwnedDate}</div>
            </div>
            <div>
              <div>creationDate</div>
              <div>{this.state.model!.creationDate}</div>
            </div>
            <div>
              <div>favoriteCount</div>
              <div>{this.state.model!.favoriteCount}</div>
            </div>
            <div>
              <div>lastActivityDate</div>
              <div>{this.state.model!.lastActivityDate}</div>
            </div>
            <div>
              <div>lastEditDate</div>
              <div>{this.state.model!.lastEditDate}</div>
            </div>
            <div>
              <div>lastEditorDisplayName</div>
              <div>{this.state.model!.lastEditorDisplayName}</div>
            </div>
            <div>
              <div>lastEditorUserId</div>
              <div>{this.state.model!.lastEditorUserId}</div>
            </div>
            <div>
              <div>ownerUserId</div>
              <div>{this.state.model!.ownerUserId}</div>
            </div>
            <div>
              <div>parentId</div>
              <div>{this.state.model!.parentId}</div>
            </div>
            <div>
              <div>postTypeId</div>
              <div>{this.state.model!.postTypeId}</div>
            </div>
            <div>
              <div>score</div>
              <div>{this.state.model!.score}</div>
            </div>
            <div>
              <div>tag</div>
              <div>{this.state.model!.tag}</div>
            </div>
            <div>
              <div>title</div>
              <div>{this.state.model!.title}</div>
            </div>
            <div>
              <div>viewCount</div>
              <div>{this.state.model!.viewCount}</div>
            </div>
          </div>
          {message}
        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedPostDetailComponent = Form.create({ name: 'Post Detail' })(
  PostDetailComponent
);


/*<Codenesium>
    <Hash>99c310fe256d01449c7d5a9ee963706e</Hash>
</Codenesium>*/