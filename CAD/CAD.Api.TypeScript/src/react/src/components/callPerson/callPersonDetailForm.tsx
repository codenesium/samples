import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CallPersonMapper from './callPersonMapper';
import CallPersonViewModel from './callPersonViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface CallPersonDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface CallPersonDetailComponentState {
  model?: CallPersonViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class CallPersonDetailComponent extends React.Component<
  CallPersonDetailComponentProps,
  CallPersonDetailComponentState
> {
  state = {
    model: new CallPersonViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.CallPersons + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.CallPersonClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.CallPersons +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new CallPersonMapper();

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
              <h3>note</h3>
              <p>{String(this.state.model!.note)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>personId</h3>
              <p>
                {String(
                  this.state.model!.personIdNavigation &&
                    this.state.model!.personIdNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>personTypeId</h3>
              <p>
                {String(
                  this.state.model!.personTypeIdNavigation &&
                    this.state.model!.personTypeIdNavigation!.toDisplay()
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

export const WrappedCallPersonDetailComponent = Form.create({
  name: 'CallPerson Detail',
})(CallPersonDetailComponent);


/*<Codenesium>
    <Hash>831a4f38fc2e20dde1532a0b95e4bdaa</Hash>
</Codenesium>*/