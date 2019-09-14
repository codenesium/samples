import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PostLinkMapper from './postLinkMapper';
import PostLinkViewModel from './postLinkViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

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
      .get<Api.PostLinkClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.PostLinks +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new PostLinkMapper();

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
              <h3>Creation Date</h3>
              <p>{String(this.state.model!.creationDate)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Link Type</h3>
              <p>
                {String(
                  this.state.model!.linkTypeIdNavigation &&
                    this.state.model!.linkTypeIdNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Post</h3>
              <p>
                {String(
                  this.state.model!.postIdNavigation &&
                    this.state.model!.postIdNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Related Post</h3>
              <p>
                {String(
                  this.state.model!.relatedPostIdNavigation &&
                    this.state.model!.relatedPostIdNavigation!.toDisplay()
                )}
              </p>
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
    <Hash>d36c52e68f97849364d7f695a6beffc1</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/