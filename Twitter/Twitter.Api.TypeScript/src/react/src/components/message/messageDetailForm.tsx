import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import MessageMapper from './messageMapper';
import MessageViewModel from './messageViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { MessengerTableComponent } from '../shared/messengerTable';

interface MessageDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface MessageDetailComponentState {
  model?: MessageViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class MessageDetailComponent extends React.Component<
  MessageDetailComponentProps,
  MessageDetailComponentState
> {
  state = {
    model: new MessageViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Messages + '/edit/' + this.state.model!.messageId
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.MessageClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Messages +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new MessageMapper();

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
              <h3>content</h3>
              <p>{String(this.state.model!.content)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>sender_user_id</h3>
              <p>
                {String(
                  this.state.model!.senderUserIdNavigation &&
                    this.state.model!.senderUserIdNavigation!.toDisplay()
                )}
              </p>
            </div>
          </div>
          {message}
          <div>
            <h3>Messengers</h3>
            <MessengerTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Messages +
                '/' +
                this.state.model!.messageId +
                '/' +
                ApiRoutes.Messengers
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

export const WrappedMessageDetailComponent = Form.create({
  name: 'Message Detail',
})(MessageDetailComponent);


/*<Codenesium>
    <Hash>13a6e573cc53bee50e0e59efe1c3a2d0</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/