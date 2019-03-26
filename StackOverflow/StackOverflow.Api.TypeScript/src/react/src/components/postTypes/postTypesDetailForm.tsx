import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PostTypesMapper from './postTypesMapper';
import PostTypesViewModel from './postTypesViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { PostsTableComponent } from '../shared/postsTable';

interface PostTypesDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface PostTypesDetailComponentState {
  model?: PostTypesViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class PostTypesDetailComponent extends React.Component<
  PostTypesDetailComponentProps,
  PostTypesDetailComponentState
> {
  state = {
    model: new PostTypesViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.PostTypes + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.PostTypesClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.PostTypes +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new PostTypesMapper();

        this.setState({
          model: mapper.mapApiResponseToViewModel(response.data),
          loading: false,
          loaded: true,
          errorOccurred: false,
          errorMessage: '',
        });
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);

        if (error.response && error.response.status == 422) {
          this.setState({
            ...this.state,
            errorOccurred: false,
            errorMessage: '',
          });
        } else {
          this.setState({
            ...this.state,
            errorOccurred: true,
            errorMessage: 'Error Occurred',
          });
        }
      });
  }

  render() {
    let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    }

    if (this.state.loading) {
      return <Spin size="large" />;
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
              <h3>Rw Type</h3>
              <p>{String(this.state.model!.rwType)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>Posts</h3>
            <PostsTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.PostTypes +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.Posts
              }
            />
          </div>
        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedPostTypesDetailComponent = Form.create({
  name: 'PostTypes Detail',
})(PostTypesDetailComponent);


/*<Codenesium>
    <Hash>aa9d07a8b434a5d329bd3b51b25f54bf</Hash>
</Codenesium>*/