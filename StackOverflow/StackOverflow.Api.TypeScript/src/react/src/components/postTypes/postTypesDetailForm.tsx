import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PostTypesMapper from './postTypesMapper';
import PostTypesViewModel from './postTypesViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
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
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.PostTypes +
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
          let response = resp.data as Api.PostTypesClientResponseModel;

          console.log(response);

          let mapper = new PostTypesMapper();

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
            loaded: true,
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
              id={this.state.model!.id}
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
    <Hash>37069099a8a3d5077c2a874dd610d3b8</Hash>
</Codenesium>*/