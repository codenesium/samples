import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { LoadingForm } from '../../lib/components/loadingForm';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PostHistoryMapper from './postHistoryMapper';
import PostHistoryViewModel from './postHistoryViewModel';
import { Form, Input, Button } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { Alert } from 'antd';

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
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.PostHistories +
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
          let response = resp.data as Api.PostHistoryClientResponseModel;

          console.log(response);

          let mapper = new PostHistoryMapper();

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
              <div>comment</div>
              <div>{this.state.model!.comment}</div>
            </div>
            <div>
              <div>creationDate</div>
              <div>{this.state.model!.creationDate}</div>
            </div>
            <div>
              <div>postHistoryTypeId</div>
              <div>{this.state.model!.postHistoryTypeId}</div>
            </div>
            <div>
              <div>postId</div>
              <div>{this.state.model!.postId}</div>
            </div>
            <div>
              <div>revisionGUID</div>
              <div>{this.state.model!.revisionGUID}</div>
            </div>
            <div>
              <div>text</div>
              <div>{this.state.model!.text}</div>
            </div>
            <div>
              <div>userDisplayName</div>
              <div>{this.state.model!.userDisplayName}</div>
            </div>
            <div>
              <div>userId</div>
              <div>{this.state.model!.userId}</div>
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
    <Hash>03548d279954f1f32ce669ee4c855f31</Hash>
</Codenesium>*/