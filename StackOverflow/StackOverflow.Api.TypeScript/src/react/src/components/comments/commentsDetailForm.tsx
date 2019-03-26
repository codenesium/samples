import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CommentsMapper from './commentsMapper';
import CommentsViewModel from './commentsViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface CommentsDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface CommentsDetailComponentState {
  model?: CommentsViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class CommentsDetailComponent extends React.Component<
  CommentsDetailComponentProps,
  CommentsDetailComponentState
> {
  state = {
    model: new CommentsViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Comments + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.CommentsClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Comments +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new CommentsMapper();

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
              <h3>Post</h3>
              <p>
                {String(
                  this.state.model!.postIdNavigation &&
                    this.state.model!.postIdNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div>
              <h3>Score</h3>
              <p>{String(this.state.model!.score)}</p>
            </div>
            <div>
              <h3>Text</h3>
              <p>{String(this.state.model!.text)}</p>
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

export const WrappedCommentsDetailComponent = Form.create({
  name: 'Comments Detail',
})(CommentsDetailComponent);


/*<Codenesium>
    <Hash>c4ef7c7c850c9234f794a8b537f37195</Hash>
</Codenesium>*/