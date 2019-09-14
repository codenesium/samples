import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PostHistoryMapper from './postHistoryMapper';
import PostHistoryViewModel from './postHistoryViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface PostHistoryDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface PostHistoryDetailComponentState {
  model?: PostHistoryViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class PostHistoryDetailComponent extends React.Component<
  PostHistoryDetailComponentProps,
  PostHistoryDetailComponentState
> {
  state = {
    model: new PostHistoryViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.PostHistories + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.PostHistoryClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.PostHistories +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new PostHistoryMapper();

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
              <h3>Comment</h3>
              <p>{String(this.state.model!.comment)}</p>
            </div>
            <div>
              <h3>Creation Date</h3>
              <p>{String(this.state.model!.creationDate)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Post History Type</h3>
              <p>
                {String(
                  this.state.model!.postHistoryTypeIdNavigation &&
                    this.state.model!.postHistoryTypeIdNavigation!.toDisplay()
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
            <div>
              <h3>Revision GUID</h3>
              <p>{String(this.state.model!.revisionGUID)}</p>
            </div>
            <div>
              <h3>Text</h3>
              <p>{String(this.state.model!.text)}</p>
            </div>
            <div>
              <h3>User Display Name</h3>
              <p>{String(this.state.model!.userDisplayName)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>User</h3>
              <p>
                {String(
                  this.state.model!.userIdNavigation &&
                    this.state.model!.userIdNavigation!.toDisplay()
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

export const WrappedPostHistoryDetailComponent = Form.create({
  name: 'PostHistory Detail',
})(PostHistoryDetailComponent);


/*<Codenesium>
    <Hash>513dd5816fdf3c86a1077dd901109a07</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/