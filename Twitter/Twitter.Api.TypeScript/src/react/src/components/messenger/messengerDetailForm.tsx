import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import MessengerMapper from './messengerMapper';
import MessengerViewModel from './messengerViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface MessengerDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface MessengerDetailComponentState {
  model?: MessengerViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class MessengerDetailComponent extends React.Component<
  MessengerDetailComponentProps,
  MessengerDetailComponentState
> {
  state = {
    model: new MessengerViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Messengers + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.MessengerClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Messengers +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new MessengerMapper();

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
              <h3>date</h3>
              <p>{String(this.state.model!.date)}</p>
            </div>
            <div>
              <h3>from_user_id</h3>
              <p>{String(this.state.model!.fromUserId)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>message_id</h3>
              <p>
                {String(
                  this.state.model!.messageIdNavigation &&
                    this.state.model!.messageIdNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div>
              <h3>time</h3>
              <p>{String(this.state.model!.time)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>to_user_id</h3>
              <p>
                {String(
                  this.state.model!.toUserIdNavigation &&
                    this.state.model!.toUserIdNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>user_id</h3>
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

export const WrappedMessengerDetailComponent = Form.create({
  name: 'Messenger Detail',
})(MessengerDetailComponent);


/*<Codenesium>
    <Hash>18ce06143a7e761158ce8e9267004bfa</Hash>
</Codenesium>*/