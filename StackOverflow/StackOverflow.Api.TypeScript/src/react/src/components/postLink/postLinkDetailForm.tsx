import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PostLinkMapper from './postLinkMapper';
import PostLinkViewModel from './postLinkViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface PostLinkDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface PostLinkDetailComponentState {
  model?: PostLinkViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class PostLinkDetailComponent extends React.Component<
  PostLinkDetailComponentProps,
  PostLinkDetailComponentState
> {
  state = {
    model: new PostLinkViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.PostLinks + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.PostLinks +
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
          let response = resp.data as Api.PostLinkClientResponseModel;

          console.log(response);

          let mapper = new PostLinkMapper();

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
              <h3>CreationDate</h3>
              <p>{String(this.state.model!.creationDate)}</p>
            </div>
            <div>
              <h3>LinkTypeId</h3>
              <p>{String(this.state.model!.linkTypeId)}</p>
            </div>
            <div>
              <h3>PostId</h3>
              <p>{String(this.state.model!.postId)}</p>
            </div>
            <div>
              <h3>RelatedPostId</h3>
              <p>{String(this.state.model!.relatedPostId)}</p>
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

export const WrappedPostLinkDetailComponent = Form.create({
  name: 'PostLink Detail',
})(PostLinkDetailComponent);


/*<Codenesium>
    <Hash>5280fcde235b222621208059e9e35174</Hash>
</Codenesium>*/